# sonosthesia-unity-demo-deform

Demo unity scenes for dynamic mesh deformations using audio source descriptor signals. Long form demo videos are available on this [YouTube playlist](https://www.youtube.com/playlist?list=PL8HqVGO27FJP4i2wh5F9h6oP8IscdKsg2). This project uses the following [Sonosthesia dependencies](https://github.com/jbat100/sonosthesia-unity-packages):

- [com.sonosthesia.processing](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.processing)
- [com.sonosthesia.signal](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.signal)
- [com.sonosthesia.flow](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.flow)
- [com.sonosthesia.target](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.target)
- [com.sonosthesia.mapping](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.mapping)
- [com.sonosthesia.noise](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.noise)
- [com.sonosthesia.mesh](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.mesh)
- [com.sonosthesia.deform](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.deform)
- [com.sonosthesia.audio](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.audio)

A Unity [timeline](https://docs.unity3d.com/Packages/com.unity.timeline@1.8/manual/index.html) is used to play audio files through audio sources. The energy in different spectral bins is [extracted]([com.sonosthesia.audio](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.audio)) and fed into [signals](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.signal) which are [mapped](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.mapping) to [targets](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.target) controlling mesh [deformation](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.deform). The deformations are implemented using the Unity Job System and Burst compiler, following Catlike coding [tutorials](https://catlikecoding.com/unity/tutorials/) (see the [mesh](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.mesh) and [noise](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.noise) packages which contain the MIT License from the author). Dynamic motion is obtained by lerping through different noise generations seeds and different noise components are controlled by different frequency bands.

Audio for these demo scenes was obtained from [epidemicsound](https://www.epidemicsound.com/), namely [jonquilla](https://www.epidemicsound.com/track/s8nGwyBhLq/) and [t1000](https://www.epidemicsound.com/track/0Xkzb9598R/). 

## Scenes

NOTE : on the first Unity editor play the audio and the graphics are out of sync, due to Unity generating runtime support files. This issue solves itself on second playback. 

### AudioTimelineLevels

This scene provides simple level bars to demonstrate control signals originating from timeline audio spectral analysis.

### AudioTimelineDynamicMeshDeform 

[Simplex](https://catlikecoding.com/unity/tutorials/pseudorandom-noise/simplex-noise/) noise with 4 different components each lerping 3 seeds on an icosphere with 2500 vertices. 75 fps on Apple M1 Pro. Having a single noise types allows a more efficient Job System dispatch.

<p align="center">
  <img src="https://github.com/jbat100/sonosthesia-unity-demo-deform/assets/1318918/9b2b6682-0e67-40b4-96fa-c3d0d54e1dbf" />
</p>

### AudioTimelineAdditiveMeshDeform

Heterogeneous noise ([Simplex](https://catlikecoding.com/unity/tutorials/pseudorandom-noise/simplex-noise/), [Voronoi](https://catlikecoding.com/unity/tutorials/pseudorandom-noise/voronoi-noise/) and [Perlin](https://catlikecoding.com/unity/tutorials/pseudorandom-noise/perlin-noise/)) with 4 different components each lerping 3 seeds on an icosphere with 2500 vertices. 63 fps on Apple M1 Pro.

<p align="center">
  <img src="https://github.com/jbat100/sonosthesia-unity-demo-deform/assets/1318918/18822877-c07e-4efc-9b4e-729a19a50469" />
</p>

### AudioTimelinePolarSine

Multichannel sound visualization using shader graph. Sine waves in polar coordinates with dynamic amplitude, phase and color intensity.

<p align="center">
  <img src="https://github.com/jbat100/sonosthesia-unity-demo-deform/assets/1318918/66ef7806-3d56-47c0-ba0f-db4ba7997a73" />
</p>


### AudioTimelineRectSine

Multichannel sound visualization using shader graph. Sine waves in cartesian coordinates with dynamic amplitude, phase and color intensity.

<p align="center">
  <img src="https://github.com/jbat100/sonosthesia-unity-demo-deform/assets/1318918/45106456-6334-4dd9-8855-6b310b26d011" />
</p>

### Spark

This scene combines job system based mesh deformations with shader graphs and vfx graphs controlled via sound descriptors with more sophisticated composition and flow elements from the Sonosthesia packages. Video with sound available [here](https://www.youtube.com/watch?v=_2siOZ5pIWQ&list=PL8HqVGO27FJP4i2wh5F9h6oP8IscdKsg2&index=5).

<p align="center">
  <img src="https://github.com/jbat100/sonosthesia-unity-demo-deform/assets/1318918/76422e27-6ea5-4c7e-be04-142d3f69d736" />
</p>

### Pollen

This scene combines job system based mesh generation following torus knot parametric curves with shader graphs and vfx graphs controlled via sound descriptors and merged with manual animations. Video with sound available [here](https://www.youtube.com/watch?v=MOeGDgMatwg&list=PL8HqVGO27FJP4i2wh5F9h6oP8IscdKsg2&index=7).


<p align="center">
  <img src="https://github.com/jbat100/sonosthesia-unity-demo-deform/assets/1318918/66da6231-09fd-49e2-a306-20e7fb50a051" />
</p>


