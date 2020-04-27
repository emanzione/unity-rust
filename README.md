# Use Rust from C# and Unity

![Banner](https://github.com/manhunterita/unity-rust/blob/master/banner.jpg)

This project is the support repository for this article: [Call into Rust from C# and Unity](http://mhlab.tech/code/csharp-rust-and-unity/)

## How to build the Rust project

Run `cargo build --release` in `Rust/` folder. It will build the library in release mode, you will find the DLL in `Rust/target/release` folder.

Place the built DLL in `Unity/Assets/Plugins`.

## Import in Unity

Open the Unity project in `Unity/` folder. Open the scene `Unity/Assets/Scenes/SampleScene`.
It contains `RustRandomTest` component that calls into `RustRandom`'s interop static functions.