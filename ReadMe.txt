TRİNGLE API

1) Çalışma ortamı olarak .Net Core 3.1 kullandım. Visual Studio ile kolayca çalıştırılabilir. Database kullanmak isterseniz PostgreSql implementasyonları yapılmıştır.
    Startup.cs sınıfında 39. satırı yoruma alıp 41, 42, 43. satırları yorumdan çıkarıp, Package Manager Console'da update-database komutu ile database hazır hale geliyor. 

2) User route => Post metotu ile kullanıcı oluşturup get metotu kullanıcı bilgilerine ulaşabilirsiniz.

3) Account create Route => Öncelikle user oluşturup sonrasında userId ile account post edebilirsiniz. Account number otomatik olarak oluşturulup eşsiz olup olmadığı kontrollor ediliyor. 

4) Account Info Route => /user get metotunu çağırarak istediğiniz kullanıcının accountNumber bilgisine ulaşıp buradan o account'un bilgilerine ulaşabilirsiniz.

5) Payment Route => /user get metotunu çağırarak istediğiniz kullanıcıların accountNumber bilgisine ulaşıp buradan payment post edebilirsiniz.
 
6) Deposit Route => /user get metotunu çağırarak istediğiniz kullanıcının accountNumber bilgisine ulaşıp buradan deposit post edebilirsiniz.

7) Withdraw Route => /user get metotunu çağırarak istediğiniz kullanıcının accountNumber bilgisine ulaşıp buradan withdraw post edebilirsiniz.

8) Transaction Route => /user get metotunu çağırarak istediğiniz kullanıcının accountNumber bilgisine ulaşıp buradan o account'un transaction bilgilerine ulaşabilirsiniz.
