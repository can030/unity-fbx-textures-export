# Unity FBX & Texture Exporter


## 🇬🇧 English

### 📋 Description

Unity Editor tool that exports FBX models with all textures in one click. Automatically finds materials, organizes files, and creates Blender-ready packages. Saves hours of manual work.

---

### ✨ Features

- 🎯 **One-Click Export** - Export models with a single button click
- 📦 **Automatic Texture Collection** - Finds all textures from materials automatically
- 🗂️ **Organized Structure** - Creates clean folder hierarchy on desktop
- 🔍 **Smart Material Scanning** - Supports Standard, URP, HDRP, and custom shaders
- 📝 **Auto Documentation** - Generates README.txt with export details
- 🚀 **Instant Access** - Automatically opens the export folder
- 🎨 **All Texture Types** - Albedo, Normal, Metallic, Emission, AO, and more
- ✅ **Safe Operation** - Never modifies original project files

---

### 📦 Installation

#### Step 1: Download

```bash
git clone https://github.com/YOUR_USERNAME/unity-fbx-texture-exporter.git
```

Or download as ZIP and extract.

#### Step 2: Add to Unity Project

1. In your Unity project, create an `Editor` folder inside `Assets` (if it doesn't exist)
2. Copy `FBXTextureExporter.cs` to `Assets/Editor/`

```
YourUnityProject/
├── Assets/
│   ├── Editor/
│   │   └── FBXTextureExporter.cs  ← Place here
│   └── ...
```

#### Step 3: Install FBX Exporter Package

1. Open Unity
2. Go to **Window > Package Manager**
3. Select **"Unity Registry"** from the top-left dropdown
4. Search for **"FBX Exporter"**
5. Click **"Install"**

![Package Manager](https://docs.unity3d.com/uploads/Main/PackageManagerUI-Main.png)

---

### 🚀 Usage

1. **Open the Tool**
   - Go to **Tools > FBX + Texture Exporter** in Unity menu

2. **Select Your Model**
   - Drag and drop a GameObject from Hierarchy or Project window
   - Or click the "Select Model" field and choose

3. **Set Folder Name**
   - Enter a name for the export folder (default: "ExportedModel")

4. **Export**
   - Click **"Export to Desktop"** button

5. **Done!**
   - The folder will automatically open on your desktop

#### Export Result Structure:

```
ExportedModel/
├── ModelName.fbx          # Your 3D model
├── Textures/              # All textures folder
│   ├── texture1.png
│   ├── texture2.jpg
│   ├── normal_map.png
│   └── ...
└── README.txt             # Export information
```

---

### ⚠️ Common Issues & Solutions

#### Issue 1: "FBX Export Failed" Error

**Symptoms:**
- FBX file is not created
- Only textures are exported
- Error message in Console

**Cause:** FBX Exporter package is not installed

**Solution:**
```
1. Open Window > Package Manager
2. Select "Unity Registry" from dropdown
3. Search for "FBX Exporter"
4. Click Install
5. Restart Unity
6. Try exporting again
```

---

#### Issue 2: No Textures Exported

**Symptoms:**
- FBX file is created
- Textures folder is empty or missing textures
- Console shows "0 textures copied"

**Cause:** Materials don't have textures assigned or textures are not in project

**Solution:**
```
1. Select your model in Unity
2. Check all materials in Inspector
3. Verify textures are assigned in material slots
4. Make sure textures are in your Assets folder (not external)
5. If using custom shaders, ensure texture properties are named correctly
```

**Additional Check:**
- Open material in Inspector
- Look for empty texture slots (grey boxes)
- Assign missing textures from your Assets

---

#### Issue 3: "Access Denied" or Folder Not Created

**Symptoms:**
- No folder appears on desktop
- Permission error in Console
- Export completes but nothing happens

**Cause:** Insufficient permissions to write to desktop

**Solution:**
```
1. Run Unity as Administrator (Windows)
   Right-click Unity icon > Run as administrator

2. Check Desktop permissions
   Right-click Desktop > Properties > Security

3. Try different location:
   Modify script line 45 to use Documents instead:
   string desktopPath = Environment.GetFolderPath(
       Environment.SpecialFolder.MyDocuments);
```

---

#### Issue 4: Script Compilation Error

**Symptoms:**
- Red errors in Console
- Script won't compile
- Tool menu doesn't appear

**Cause:** Script is not in correct location or Unity version incompatibility

**Solution:**
```
1. Verify file location: Assets/Editor/FBXTextureExporter.cs
2. Check Unity version (requires 2019.4 or newer)
3. Delete and re-import the script
4. Check Console for specific error messages
5. Ensure no other scripts have compilation errors
```

---

#### Issue 5: Wrong Textures Exported

**Symptoms:**
- Some textures are missing
- Duplicate textures
- Unrelated textures included

**Cause:** Multiple materials or shared textures

**Solution:**
```
1. Script exports ALL textures from model and children
2. If you only want specific materials:
   - Duplicate your model
   - Remove unwanted child objects
   - Export the cleaned model

3. Check for shared materials:
   - Open material
   - See which objects use it
   - Unassign from unwanted objects if needed
```

---

#### Issue 6: Large File Sizes

**Symptoms:**
- Export takes long time
- Folder size is very large
- Many duplicate textures

**Cause:** High-resolution textures or duplicates

**Solution:**
```
1. The tool copies original texture files
2. To reduce size:
   - Compress textures in Unity before export
   - Use lower resolution textures
   - Remove duplicate materials

3. After export, you can:
   - Manually delete unused textures from Textures folder
   - Compress images using external tools
```

---

### 🛠️ Requirements

- Unity 2019.4 or newer
- FBX Exporter Package (free, from Package Manager)
- Windows, macOS, or Linux

---

### 📝 Notes

- This tool runs in Unity Editor only (not in builds)
- Original project files are never modified
- Export always goes to Desktop (customizable in code)
- Supports all render pipelines (Built-in, URP, HDRP)

---

### 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

---

### 📄 License

MIT License - See LICENSE file for details

---


## 🇹🇷 Türkçe

### 📋 Açıklama

Unity modellerini texture'larıyla tek tıkla FBX olarak aktaran araç. Material'leri otomatik bulur, dosyaları organize eder. Blender için hazır paket oluşturur.

---

### ✨ Özellikler

- 🎯 **Tek Tıklama ile Dışa Aktarma** - Tek buton ile modeli dışa aktarın
- 📦 **Otomatik Texture Toplama** - Material'lerden tüm texture'ları otomatik bulur
- 🗂️ **Düzenli Yapı** - Masaüstünde temiz klasör hiyerarşisi oluşturur
- 🔍 **Akıllı Material Tarama** - Standard, URP, HDRP ve custom shader'ları destekler
- 📝 **Otomatik Dokümantasyon** - Export detaylarıyla README.txt oluşturur
- 🚀 **Anında Erişim** - Export klasörünü otomatik açar
- 🎨 **Tüm Texture Tipleri** - Albedo, Normal, Metallic, Emission, AO ve daha fazlası
- ✅ **Güvenli İşlem** - Orijinal proje dosyalarını asla değiştirmez

---

### 📦 Kurulum

#### Adım 1: İndirin

```bash
git clone https://github.com/KULLANICI_ADINIZ/unity-fbx-texture-exporter.git
```

Veya ZIP olarak indirip açın.

#### Adım 2: Unity Projenize Ekleyin

1. Unity projenizde `Assets` içinde `Editor` klasörü oluşturun (yoksa)
2. `FBXTextureExporter.cs` dosyasını `Assets/Editor/` klasörüne kopyalayın

```
UnityProjeniz/
├── Assets/
│   ├── Editor/
│   │   └── FBXTextureExporter.cs  ← Buraya koyun
│   └── ...
```

#### Adım 3: FBX Exporter Package'ı Yükleyin

1. Unity'yi açın
2. **Window > Package Manager** gidin
3. Sol üstteki dropdown'dan **"Unity Registry"** seçin
4. **"FBX Exporter"** aratın
5. **"Install"** butonuna tıklayın

![Package Manager](https://docs.unity3d.com/uploads/Main/PackageManagerUI-Main.png)

---

### 🚀 Kullanım

1. **Aracı Açın**
   - Unity menüsünden **Tools > FBX + Texture Exporter** seçin

2. **Modelinizi Seçin**
   - Hierarchy veya Project penceresinden bir GameObject sürükleyin
   - Veya "Model Seç" alanına tıklayıp seçin

3. **Klasör Adını Belirleyin**
   - Export klasörü için bir isim girin (varsayılan: "ExportedModel")

4. **Dışa Aktarın**
   - **"Masaüstüne Dışa Aktar"** butonuna tıklayın

5. **Hazır!**
   - Klasör otomatik olarak masaüstünüzde açılacak

#### Export Sonuç Yapısı:

```
ExportedModel/
├── ModelAdi.fbx           # 3D modeliniz
├── Textures/              # Tüm texture'lar klasörü
│   ├── texture1.png
│   ├── texture2.jpg
│   ├── normal_map.png
│   └── ...
└── README.txt             # Export bilgileri
```

---

### ⚠️ Sık Karşılaşılan Sorunlar ve Çözümler

#### Sorun 1: "FBX Export Başarısız" Hatası

**Belirtiler:**
- FBX dosyası oluşturulmuyor
- Sadece texture'lar dışa aktarılıyor
- Console'da hata mesajı

**Neden:** FBX Exporter package yüklü değil

**Çözüm:**
```
1. Window > Package Manager açın
2. Dropdown'dan "Unity Registry" seçin
3. "FBX Exporter" aratın
4. Install butonuna tıklayın
5. Unity'yi yeniden başlatın
6. Tekrar dışa aktarmayı deneyin
```

---

#### Sorun 2: Texture'lar Dışa Aktarılmıyor

**Belirtiler:**
- FBX dosyası oluşuyor
- Textures klasörü boş veya eksik texture'lar var
- Console'da "0 textures copied" yazıyor

**Neden:** Material'lerde texture atanmamış veya texture'lar projede yok

**Çözüm:**
```
1. Unity'de modelinizi seçin
2. Inspector'da tüm material'leri kontrol edin
3. Material slot'larında texture'ların atandığını doğrulayın
4. Texture'ların Assets klasöründe olduğundan emin olun (harici değil)
5. Custom shader kullanıyorsanız, texture property isimlerinin doğru olduğundan emin olun
```

**Ek Kontrol:**
- Material'i Inspector'da açın
- Boş texture slot'larına bakın (gri kutular)
- Assets'inizden eksik texture'ları atayın

---

#### Sorun 3: "Erişim Engellendi" veya Klasör Oluşturulmadı

**Belirtiler:**
- Masaüstünde klasör görünmüyor
- Console'da izin hatası
- Export tamamlanıyor ama hiçbir şey olmuyor

**Neden:** Masaüstüne yazma izni yok

**Çözüm:**
```
1. Unity'yi Yönetici olarak çalıştırın (Windows)
   Unity ikonuna sağ tık > Yönetici olarak çalıştır

2. Masaüstü izinlerini kontrol edin
   Masaüstüne sağ tık > Özellikler > Güvenlik

3. Farklı konum deneyin:
   Script'teki 45. satırı değiştirerek Belgeler kullanın:
   string desktopPath = Environment.GetFolderPath(
       Environment.SpecialFolder.MyDocuments);
```

---

#### Sorun 4: Script Derleme Hatası

**Belirtiler:**
- Console'da kırmızı hatalar
- Script derlenmiyor
- Tool menüsü görünmüyor

**Neden:** Script doğru konumda değil veya Unity versiyonu uyumsuz

**Çözüm:**
```
1. Dosya konumunu doğrulayın: Assets/Editor/FBXTextureExporter.cs
2. Unity versiyonunu kontrol edin (2019.4 veya daha yeni gerekli)
3. Script'i silin ve tekrar import edin
4. Console'daki spesifik hata mesajlarını kontrol edin
5. Başka script'lerde derleme hatası olmadığından emin olun
```

---

#### Sorun 5: Yanlış Texture'lar Dışa Aktarıldı

**Belirtiler:**
- Bazı texture'lar eksik
- Tekrarlı texture'lar
- İlgisiz texture'lar dahil edilmiş

**Neden:** Birden fazla material veya paylaşılan texture'lar

**Çözüm:**
```
1. Script model ve alt objelerden TÜM texture'ları dışa aktarır
2. Sadece belirli material'leri istiyorsanız:
   - Modelinizi kopyalayın
   - İstenmeyen alt objeleri silin
   - Temizlenmiş modeli dışa aktarın

3. Paylaşılan material'leri kontrol edin:
   - Material'i açın
   - Hangi objelerin kullandığını görün
   - Gerekirse istenmeyen objelerden atamayı kaldırın
```

---

#### Sorun 6: Büyük Dosya Boyutları

**Belirtiler:**
- Export uzun sürüyor
- Klasör boyutu çok büyük
- Çok fazla tekrar eden texture

**Neden:** Yüksek çözünürlüklü texture'lar veya tekrarlar

**Çözüm:**
```
1. Araç orijinal texture dosyalarını kopyalar
2. Boyutu azaltmak için:
   - Export öncesi Unity'de texture'ları sıkıştırın
   - Daha düşük çözünürlüklü texture'lar kullanın
   - Tekrar eden material'leri kaldırın

3. Export sonrası:
   - Textures klasöründen kullanılmayan texture'ları manuel silebilirsiniz
   - Harici araçlarla resimleri sıkıştırabilirsiniz
```

---

### 🛠️ Gereksinimler

- Unity 2019.4 veya daha yeni
- FBX Exporter Package (ücretsiz, Package Manager'dan)
- Windows, macOS veya Linux

---

### 📝 Notlar

- Bu araç sadece Unity Editor'da çalışır (build'lerde değil)
- Orijinal proje dosyaları asla değiştirilmez
- Export her zaman Masaüstüne gider (kodda özelleştirilebilir)
- Tüm render pipeline'ları destekler (Built-in, URP, HDRP)

---

### 🤝 Katkıda Bulunma

Katkılar memnuniyetle karşılanır! Pull Request göndermekten çekinmeyin.

---

### 📄 Lisans

MIT Lisansı - Detaylar için LICENSE dosyasına bakın

---

## 🌟 Support / Destek

If you like this project, please give it a ⭐!

Bu projeyi beğendiyseniz ⭐ vermeyi unutmayın!
