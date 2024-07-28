Key:
event handlers

 terdapat potensi kebocoran memori yang disebabkan oleh penggunaan event handlers. 
 Ketika objek EventSubscriber berlangganan ke event MyEvent dari EventPublisher, referensi ke subscriber disimpan oleh publisher. 
 Jika subscriber tidak berhenti berlangganan dari event sebelum dihapus, referensi tersebut tetap ada, menyebabkan kebocoran memori karena garbage collector tidak dapat membersihkan objek EventSubscriber.

Dalam loop while (true), objek EventSubscriber baru dibuat pada setiap iterasi dan berlangganan ke event MyEvent dari EventPublisher.
Karena event handler OnMyEvent tetap terdaftar pada publisher, referensi ke subscriber tidak akan dihapus oleh garbage collector.
Karena referensi ke subscriber tetap ada di event handler, memori yang digunakan oleh objek EventSubscriber tidak dibebaskan, menyebabkan kebocoran memori.

Untuk menghindari kebocoran memori, kita harus memastikan bahwa subscriber berhenti berlangganan dari event ketika tidak lagi diperlukan. 
Salah satu cara untuk melakukannya adalah dengan menggunakan pattern Dispose.

using System;

namespace MemoryLeakExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new EventPublisher();
            while (true)
            {
                using (var subscriber = new EventSubscriber(publisher))
                {
                    // do something with the publisher and subscriber objects
                }
            }
        }
    }

    class EventPublisher
    {
        public event EventHandler MyEvent;

        public void RaiseEvent()
        {
            MyEvent?.Invoke(this, EventArgs.Empty);
        }

        public void Unsubscribe(EventHandler handler)
        {
            MyEvent -= handler;
        }
    }

    class EventSubscriber : IDisposable
    {
        private EventPublisher _publisher;
        private EventHandler _handler;

        public EventSubscriber(EventPublisher publisher)
        {
            _publisher = publisher;
            _handler = new EventHandler(OnMyEvent);
            _publisher.MyEvent += _handler;
        }

        private void OnMyEvent(object sender, EventArgs e)
        {
            Console.WriteLine("MyEvent raised");
        }

        public void Dispose()
        {
            // Unsubscribe from the event to avoid memory leaks
            if (_publisher != null)
            {
                _publisher.Unsubscribe(_handler);
                _publisher = null;
            }
        }
    }
}

EventSubscriber mengimplementasikan interface IDisposable yang menyediakan metode Dispose untuk membersihkan resource yang tidak dikelola.
Di dalam metode Dispose, subscriber berhenti berlangganan dari event MyEvent dengan memanggil metode Unsubscribe dari EventPublisher.
Di dalam loop while (true), using digunakan untuk memastikan bahwa metode Dispose dipanggil secara otomatis ketika objek EventSubscriber tidak lagi diperlukan.

Dengan memastikan bahwa subscriber berhenti berlangganan dari event ketika tidak lagi diperlukan, kita dapat menghindari kebocoran memori yang disebabkan oleh referensi event handler yang tetap ada. Pendekatan ini menggunakan pattern Dispose untuk membersihkan resource dan memastikan bahwa memori dikelola dengan baik.