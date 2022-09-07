
# Educourse.Api



## Kullanılan Teknolojiler

.Net 5.0, MongoDB

  
## DB Bağlantısı 

Mongo shelli açın.

```bash 
mongosh
```
    
"user" ismindeki databasimizi aşağıdaki komutla oluşturuyoruz.

```bash 
  use user
```
"users" ismindeki koleksiyonumuz oluşturuyoruz.

```bash 
  db.createCollection('users')
```

    
```bash 
  db.users.insertOne({
  "Email": "admin@gmail.com",
  "Password": "admin123"
})
```
    
Oluşturduğumuz collectionu kontrol ediyoruz.
```bash 
  db.users.find().pretty()
```
    
## Bilgisayarınızda Çalıştırın

Projeyi klonlayın

```bash
  git clone https://github.com/MebitamDev/Educourse.Api
```

Proje dizinine gidin

```bash
  cd Educourse.Api
  cd webapi
```

Gerekli paketleri yükleyin

```bash
  dotnet build
```

Sunucuyu çalıştırın

```bash
  dotnet run
```

  
