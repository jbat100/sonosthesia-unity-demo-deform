# sonosthesia-unity-demo-deform

Demo unity scenes for dynamic mesh deformations using audio source descriptor signals. This project uses the following [Sonosthesia dependencies](https://github.com/jbat100/sonosthesia-unity-packages):

- [com.sonosthesia.processing](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.processing)
- [com.sonosthesia.signal](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.signal)
- [com.sonosthesia.flow](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.flow)
- [com.sonosthesia.target](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.target)
- [com.sonosthesia.mapping](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.mapping)
- [com.sonosthesia.noise](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.noise)
- [com.sonosthesia.mesh](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.mesh)
- [com.sonosthesia.deform](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.deform)
- [com.sonosthesia.audio](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.audio)

A Unity [timeline](https://docs.unity3d.com/Packages/com.unity.timeline@1.8/manual/index.html) is used to play audio files through audio sources. The energy in different spectral bins is [extracted]([com.sonosthesia.audio](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.audio)) and fed into [signals](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.signal) which are [mapped](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.mapping) to [targets](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.target) controlling mesh [deformation](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.deform). The deformations are implemented using the Unity Job System and Burst compiler, following Catlike coding [tutorials](https://catlikecoding.com/unity/tutorials/) (see the [mesh](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.mesh) and [noise](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.noise) packages). 

## Scenes

<p align="center">
  <img src="https://github.com/jbat100/sonosthesia-unity-demo-deform/assets/1318918/9b2b6682-0e67-40b4-96fa-c3d0d54e1dbf" />
</p>

<p align="center">
  <img src="https://github.com/jbat100/sonosthesia-unity-demo-deform/assets/1318918/18822877-c07e-4efc-9b4e-729a19a50469" />
</p>
