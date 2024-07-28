//kode asli
if (application != null)
{
 if (application.protected != null)
 {
 return application.protected.shieldLastRun;
 }

 // Perbaikan dengan menggunakan operator null-conditional dan null-coalescing
return application?.protected?.shieldLastRun ?? defaultValue;
}