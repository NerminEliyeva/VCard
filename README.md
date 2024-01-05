# VCard

Bu C# konsol proqramı RandomUser.me API-dən təsadüfi istifadəçi məlumatlarını çıxarır və bu məlumatları vCard (Virtual Əlaqə Faylı) formatına çevirir və faylda saxlayır.

## İstifadə olunan APİ

Bu proqram [RandomUser.me](https://randomuser.me/) API-dən istifadə edir. API-dən məlumatları əldə etmək üçün HTTP sorğusu göndərir və qəbul etdiyi JSON məlumatlarını VCard sinfinə çevirir.

## VCard Sinfi

`VCard` sinfi aşağıdakı xüsusiyyətlərə malikdir:
- Id
- Firstname
- Surname
- Email
- Phone
- Country
- City

## İstifadə qaydası

Tətbiq işə salındıqda istifadəçidən neçə vCard yaratması soruşulacaq. Yaradılmış vCard-lar .vcf uzantılı fayllar kimi layihə qovluğunda "Files" qovluğunda saxlanılacaq.

## Əlavə informasiya

- Bu layihə C# dilində HTTP sorğuları, JSON məlumatların emalı, obyekt yönümlü proqramlaşdırma və fayl əməliyyatları kimi mövzuları təcrübədən keçirmək üçün yaradılmışdır.
- Layihədə istifadə olunan API [RandomUser.me](https://randomuser.me/) tərəfindən təmin edilir.

