## Docker üzerinde uygulamaya eriþim linkleri
	- API => http://localhost:5000/swagger

## Uygulamayý Baþlatma
	- docker-compose up

Komutunu ana dizin içerisinde çalýþtýrmanýz halinde API ve REDIS uygulamalarý docker uzerinde çalýþýr hale gelecektir.

## Uygulamanýn çalýþabilmesi için gerekenler
	- Docker veya .net 5.0 support
	- Redis (Port: 6379)

## Case tipleri hakkýnda
	- Seed aþamasýnda aþaðýdaki tiplerde örnek veriler oluþturacaktýr.
		- online
		- offline
		- usa
		- uk
	- Api'lere istek atabilmek için type olarak parametre eklenmiþtir
	- type parametresi dökümanda bahsi geçen case tiplerine karþýlýk gelmektedir.