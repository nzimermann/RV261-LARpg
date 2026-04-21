# RV261-LARpg

Aplicação de realidade aumentada feita no Unity

## Pré-requisitos

Os seguintes pacotes precisam ser instalados:

* Ubuntu

```bash
sudo apt install adb android-sdk-platform-tools-common
```

* Arch

```bash
pacman -S adb android-udev
```

* **Unity Hub** e **Unity 6.3 LTS 6000.3.10.f1**
* **Módulos do Unity:** Durante a instalação do Unity marcar o **Android Build Support** e suas duas sub-opções: **OpenJDK** e **Android SDK & NDK Tools**.
* Um **dispositivo Android** e um **cabo USB** para conectar no computador.

## Passo a passo para compilar e rodar

**1. Preparar o celular**

* Nas configurações do Android entre no menu **Sobre o telefone**.
* Toque 7 vezes seguidas no **Número da Versão** (ou *Build Number*) para habilitar o modo desenvolvedor.
* Acesse as novas opções de desenvolvedor e ative a **Depuração USB**.

**2. Conectar e autorizar o computador**

* Conecte o celular ao computador via cabo USB.
* Abra o terminal ou prompt de comando do seu sistema operacional e digite:

```bash
adb devices
```

* **Tela do celular:** O comando forçará o aparecimento de uma janela perguntando "Permitir depuração USB?". Permita a opção.
* Rode `adb devices` novamente. O aparelho deve aparecer na lista com a palavra `device` ao lado (se aparecer `unauthorized`, a permissão na tela do celular não foi confirmada).

**3. Configurar o Projeto no Unity**

* Abra o projeto.
* Vá em **File > Build Profiles**, selecione a plataforma **Android** e clique em **Switch Platform**.
* Vá em **Edit > Project Settings > Player**, expanda **Other Settings** e altere:
* **Package Name:** Defina um identificador único (ex: `com.SeuNome.NomeDoProjeto`).
* **Minimum API Level:** Ajuste para o mínimo exigido pelo ARCore (Android 7.0 / API Level 24 ou superior).
* **Scripting Backend:** Mude para **IL2CPP**.
* **Target Architectures:** Desmarque `ARMv7` e marque apenas **ARM64**.
* Ainda no *Project Settings*, vá na aba **XR Plug-in Management** e marque a caixa do **ARCore** na seção do Android.

**4. Instalar no Celular**

* Volte à janela **Build Profiles**.
* Na opção **Run Device**, clique em atualizar e selecione o aparelho que foi conectado.
* Clique em **Build And Run**. O Unity irá compilar o aplicativo e abri-lo automaticamente na tela do celular.
