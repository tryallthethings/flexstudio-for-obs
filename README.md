# Flexstudio for OBS

![Downloads](https://img.shields.io/github/downloads/tryallthethings/flexstudio-for-obs/total.svg?style=flat)
[![GitHub license](https://img.shields.io/github/license/tryallthethings/flexstudio-for-obs)](https://github.com/tryallthethings/flexstudio-for-obs/blob/main/LICENSE)
[![GitHub release](https://img.shields.io/github/release/tryallthethings/flexstudio-for-obs.svg)](https://GitHub.com/tryallthethings/flexstudio-for-obs/releases/)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7%2B-blue)
![Platform](https://img.shields.io/badge/platform-Windows%2010%20%7C%2011-lightgrey)

Flexstudio for OBS is an innovative, open-source utility that offers a seamless way to make OBS Studio fully portable. Developed using C#, this solution is compatible with .NET Framework 4.7 or higher and optimized for Windows 10 and 11. No extra installation / setup is required and it doesn't leave anything behind. It's easy to use, requires no installation and has a modern user interface.

## 🌟 Features

- **Portability**: Flexstudio for OBS optimizes your portability by cleverly assigning a consistent (virtual) drive letter to your portable OBS Studio folder, regardless of the machine you're using. If you start the tool from a USB stick, Flexstudio for OBS ensures that OBS Studio always "sees" the same drive letter. This approach utilizes built-in Windows mechanisms, requiring no extra setup from the user, providing a hassle-free and portable experience. 
- **Version Management**: Flexstudio for OBS can maintain one local and multiple portable versions of OBS, download new versions, and backup existing ones.
- **Backup**: Safeguard your OBS profiles, maintaining the integrity of your settings.
- **Smart Management**: Flexstudio for OBS maintains an overview of the running OBS versions, ensuring each version is only started once. This tracking persists even if the tool itself is closed or restarted, offering a seamless user experience.
- **Automated Convenience**: Comes with an automation feature, which upon tool start, can automatically map the virtual drive and launch OBS. This functionality can be customized as per the user's preference.

## 🌍 Multi-Language Support

Flexstudio currently supports English and German. We invite and welcome contributions for adding support for other languages.

## 🛑 Limitations

- **Audio and video devices**: Audio and video devices such as soundcards and webcams are machine specific and you will always need to select them again on each PC your are starting OBS on.

## 🎨 Future Plans

- **Theming**: Customization options to give Flexstudio a personalized touch.
- **Restore Functionality**: Restoring full OBS versions or specific profiles.
- **Auto-Updates**: Updating existing OBS portable versions to the latest or any other version (choosable by the user).
- **Cloud Backup**: Offering backup/restore functionality to and from cloud services such as Dropbox, Google Drive, NextCloud, etc.
- **Drive Letter Modification**: Altering the drive letter for portable OBS versions in their respective config/profile if the assigned drive letter is already in use.
- **Automated Backup**: Upon closing the tool and updating an OBS version

## 🛡️ Permissions

Flexstudio operates without requiring elevated permissions, providing a user-friendly experience without compromising system security.

## 🚀 Quickstart

1. Download the latest release from [https://github.com/tryallthethings/flexstudio-for-obs/releases/latest](https://github.com/tryallthethings/flexstudio-for-obs/releases/latest)
2. Place it in a folder of your choice (for example on an USB stick) and start it. ❗ *To keep things organized and tidy I recommend a new folder as the tool creates a few subfolders and a config file in the folder it is started from.* 
3. Go to the settings tab and select the virtual drive letter you want to use.
4. Click map drive on the dashboard tab.
5. Download an OBS version on the OBS versions tab and click *Start* to start it. This will start the OBS version on the virtual drive you selected. If you now add media (images, sounds, videos, etc.) to your OBS scenes make sure you are selecting them on the virtual drive.

## 📚 How to Use / Documentation

Detailed usage instructions and documentation can be found [here](https://tryallthethings.github.io/flexstudio-for-obs/).

## 📃 License

Flexstudio for OBS is licensed under the terms of the GPLv3. You can review the details in the [LICENSE](LICENSE) file.