Ýlk aþamada projeyi Beyin (UstaPlatform.Domain), Eklentiler (UstaPlatform.Rules) ve Ana Program (UstaPlatform.App) olarak üçe ayýrdým. 
1-Beyin (UstaPlatform.Domain): Bu projeye Usta, IsEmri gibi temel sýnýflarý ve en önemlisi, tüm fiyat kurallarýnýn uymak zorunda olduðu IPricingRule adýnda bir arayüz (bir nevi þablon) koydum. Bu proje en temelde duruyor ve kimseye baðýmlý deðil.
2- Eklentiler (UstaPlatform.Rules): Bunlar Rules.Haftasonu gibi küçük projeler. Hepsi Domain'deki IPricingRule þablonunu alýp içini dolduruyor .Her biri ayrý bir .dll dosyasý üretiyor.
3-UstaPlatform.App (Ana Program): Burasý konsol uygulamasý. Ýçine PricingEngine (Fiyat Motoru) adýnda bir sýnýf yazdým. Bu motor program açýlýrken plugins diye bir klasöre bakýyor, içindeki tüm .dll'leri bulup okuyor ve IPricingRule þablonuna uyan kurallarý hafýzaya atýyor. Fiyat hesaplarken de bu listedeki tüm kurallarý sýrayla çalýþtýrýyor.

-- Nasýl Çalýþtýrýlýr? --
1- Öncelikle tüm projeleri derleyin.
2- UstaPlatform.App projesinin çalýþtýrýlabilir dosyasýnýn (UstaPlatform.App\bin\Debug\net6.0\) içindeki "plugins" klasörüne gidin.
3- Eklentiler (UstaPlatform.Rules) projesinin derlenmiþ .dll dosyalarýný (örneðin Rules.Haftasonu.dll) bu "plugins" klasörüne kopyalayýn.
4- Þimdi UstaPlatform.App projesini çalýþtýrabilirsiniz. Program, "plugins" klasöründeki tüm kurallarý otomatik olarak yükleyecek ve fiyat hesaplamalarýnda kullanacaktýr.
-- Nasýl Yeni Kural Eklenir? --
1- UstaPlatform.Rules projesine yeni bir sýnýf ekleyin (örneðin Rules.OzelIndirim).
2- Bu sýnýfýn IPricingRule arayüzünü implemente ettiðinden emin olun ve gerekli metotlarý doldurun.
3- Projeyi derleyin. Yeni .dll dosyasýný "plugins" klasörüne kopyalayýn.
4- UstaPlatform.App projesini yeniden baþlatýn. Yeni kural otomatik olarak yüklenecektir.
-- Notlar --
- Her kuralýn doðru çalýþtýðýndan emin olmak için birim testleri yazmayý unutmayýn.
- Fiyat hesaplama sýrasýný deðiþtirmek isterseniz, PricingEngine sýnýfýnda kurallarý yükleme sýrasýný düzenleyebilirsiniz.
- Gelecekte yeni kurallar eklemek oldukça kolay olacak þekilde tasarlandý, bu yüzden ihtiyaç duydukça yeni eklentiler oluþturabilirsiniz.
- Herhangi bir sorunla karþýlaþýrsanýz, lütfen proje dokümantasyonuna veya kaynak koduna bakýn.
- Ýyi çalýþmalar ve baþarýlar dilerim!