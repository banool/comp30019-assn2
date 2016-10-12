Rolly Mountain - a game by Daniel Porteous (696965) and Hugh Edwards (584183). It was built for the University of Melbourne subject Graphics and Interaction, and made with Unity 5.3 for the Microsoft Surface.

YouTube demonstration
https://www.youtube.com/watch?v=fTZ0RdtsIEg&feature=youtu.be

See it deployed for WebGL (use Firefox):
https://dl.dropboxusercontent.com/u/36382318/finalWebGL/index.html


-- Versions

Version 1 - completed 13th October 2016.


-- Description

	Rolly Mountain is a game where the player controls a ball with the aim of surviving for the longest period and maximising their score. The ball is rolling down a pseudo-endless slope with randomly spawning obstacles. The player controls the left and right motion of the ball, and can jump over obstacles. The game ends if the player falls into the water, or collides with an obstacle. The game has a menu from which the gameplay can be accessed. A score keeps track player performance (and the rate at which score increases is proportional to player speed). It was designed for the Microsoft Surface.
	

-- Controls
	
	The menu may be navigated with touch (algernatively, with mouse clicks).

	Horizontal movement - Tilt the device from side to side (alternatively, use the left and right arrow keys)

	Jump - Tap the screen (alternatively, press the space bar).


-- Object Modelling

	-- Objects

		Objects are all basic, default three dimension geometric objects as sets of polygons in Unity (quads, cubes, a pseudo-sphere). 

	-- Physics

		The unity physics engine is used to govern the interaction between the ball and the world. Player control is implemented via the addition of forces to the ball.


-- Graphics

	--Shaders

		-- Phong

			Generic objects are displayed with a custom shader implementing the Phong Shader. Textures are used to enhance object presenttation.

		-- Bump-mapping

			The player's sphere is a bump-mapped sphere made to look like bricks. This is done by applying a normal map to the object as well as a texture.

		-- Water

			The water is a semi-transparent textureless shader which also implements phong components (ambient, diffuse, specular). This was achieved by alterring the alpha component of the vertex colour values, and setting the RenderType to transparent. Specularity is increased to create a shiny effect. This allows the player to see the dirt moving beneath the water.

		-- Shadow volumes

			Shadow volumes are implemented with Unity's built in shadow maps in the shaders of certain objects, such as the terrain.

		-- Fog

			Fog is implemented on certain objects (eg the slope, obstacles) to obscure those that are 'fading' into the distance. A custom fog shader is used here. These objects are also textured, so that the fog colour is blended onto the texture based on how far the object is from the camera. The attenuation factor determines how much of the original vertex colour is attenuated by the fog colour.

	-- Particles

		The Unity particle system is utilised to create dust particles when the player impacts the terrain

	-- Camera Motion

		The transform component of the camera is associated with the player such that it remains a fixed offset above and behind the player. The camera orientation is such that the 'action' is visible.


-- Resources

	-- Textures

		The brick texture and normal maps are taken from workshop 7.

		Tree textures were taken from
		here: https://s-media-cache-ak0.pinimg.com/originals/bf/4e/3d/bf4e3d78add13f8d8dfd593ed7e6e0c1.jpg
		here: http://1.bp.blogspot.com/-bZgY2Iwy0IE/U84TxKATRhI/AAAAAAAAFm0/vaF2QJNpLXs/s1600/Plant+hedge+bush+leaf+leaves+texture.jpg

		The terrain, obstacle and dirt textures are taken from the Unity Standard Assets.

	-- Code inspiration

		The shader PhongShaderTransparent is based upon a shader implemented in our Project 1 solution.

		Portions of the two shaders PhongShaderBumpTex and CubeShaderTex are inspired by lab code written by Alexandre Mutel, with edits by Jeremy Nicholson, Chris Ewin, and Alex Zable.

		PassArrayToShader: a generic script used to pass arrays to shaders. The script, and its use in TexApplier, is inspired by lab material, from http://www.alanzucconi.com/2016/01/27/arrays-shaders-heatmaps-in-unity3d/

	-- Sound

		The explosion sound on player death was taken from https://www.freesoundeffects.com/free-sounds/explosion-10070/

	-- Music

		Music was written and performed by Daniel Porteous.

	-- Skybox

		The skybox (not visible in final game, but visible on the welcome screen) was painted by Daniel Porteous.




