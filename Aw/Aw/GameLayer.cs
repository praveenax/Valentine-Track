using System;
using System.Collections.Generic;
using CocosSharp;

using Box2D;

using Microsoft.Xna;

namespace Aw
{
	public class GameLayer : CCLayerGradient
	{
		CCParticleSystem galaxySystem;

		CCSprite monkeySprite1;
		CCSprite monkeySprite2;

		CCSprite hero;


		CCSprite floorClone;
		CCSprite floorClone2;
		CCSprite floorClone3;
		CCSprite floorClone4;
		CCSprite floorClone5;
		CCSprite floorClone6;

	//	CCSprite changeDirection;

		CCSprite tunnel;
		CCSprite tunnel2;
		CCSprite tunnel3;
		CCSprite tunnel4;

		CCRepeatForever repeatedAction;
		CCSpawn dreamAction;

		float heroMoveSpeedX = 10f;
		float heroMoveSpeedY = 0f;

		float XMaxValue = 0f;
		float YMaxValue = 0f;

		float XMinValue = 0f;
		float YMinValue = 0f;


		void initSprites ()
		{
			monkeySprite1 = new CCSprite ("monkey");
			//changeDirection = new CCSprite ("hero");
			floorClone = new CCSprite ("floor3");
			floorClone2 = new CCSprite ("floor3");
			floorClone3 = new CCSprite ("floor3");
			floorClone4 = new CCSprite ("floor3");
			floorClone5 = new CCSprite ("floor3");
			floorClone6 = new CCSprite ("floor3");
			hero = new CCSprite ("hero");
			tunnel = new CCSprite ("tunnel");
			tunnel2 = new CCSprite ("tunnel");
			tunnel3 = new CCSprite ("tunnel");
			tunnel4 = new CCSprite ("tunnel");



		}

		void scaleSprites ()
		{
		

			floorClone.ScaleX = floorClone.ScaleX * 1f;
			floorClone.ScaleY = floorClone.ScaleY * 0.5f;

			floorClone2.ScaleX = floorClone2.ScaleX * 1f;
			floorClone2.ScaleY = floorClone2.ScaleY * 0.5f;

			floorClone3.ScaleX = floorClone3.ScaleX * 1f;
			floorClone3.ScaleY = floorClone3.ScaleY * 0.5f;

			floorClone4.ScaleX = floorClone4.ScaleX * 1f;
			floorClone4.ScaleY = floorClone4.ScaleY * 0.5f;

			floorClone5.ScaleX = floorClone5.ScaleX * 1f;
			floorClone5.ScaleY = floorClone5.ScaleY * 0.5f;

			floorClone6.ScaleX = floorClone6.ScaleX * 1f;
			floorClone6.ScaleY = floorClone6.ScaleY * 0.5f;


			hero.ScaleX = hero.ScaleX * 0.5f;
			hero.ScaleY = hero.ScaleY * 0.5f;

			tunnel.ScaleX = tunnel.ScaleX * 1.5f;
			tunnel.ScaleY = tunnel.ScaleY * 1.5f;

			tunnel2.ScaleX = tunnel2.ScaleX * 1.5f;
			tunnel2.ScaleY = tunnel2.ScaleY * 1.5f;

			tunnel3.ScaleX = tunnel3.ScaleX * 1.5f;
			tunnel3.ScaleY = tunnel3.ScaleY * 1.5f;

			tunnel4.ScaleX = tunnel4.ScaleX * 1.5f;
			tunnel4.ScaleY = tunnel4.ScaleY * 1.5f;

			//changeDirection
			//changeDirection.ScaleX = changeDirection.ScaleX * 0.5f;
			//changeDirection.ScaleY = changeDirection.ScaleY * 0.5f;
		
		}

		void addChildNodes ()
		{

			AddChild (floorClone, 1);
			AddChild (floorClone2, 1);
			AddChild (floorClone3, 1);
			AddChild (floorClone4, 1);
			AddChild (floorClone5, 1);
			AddChild (floorClone6, 1);
			AddChild (hero, 2);
			AddChild (tunnel, 3);
			AddChild (tunnel2, 3);
			AddChild (tunnel3, 3);
			AddChild (tunnel4, 3);

			//	AddChild (changeDirection, 3);

		}

		//	int redColorIncrement = 10;


		public GameLayer ()
			: base (CCColor4B.Blue, CCColor4B.White)
		{
			// Set the layer gradient direction
			this.Vector = new CCPoint (0f, 0.5f);

			// Create and add sprites

			initSprites ();
			scaleSprites ();
			addChildNodes ();


			//	AddChild (monkeySprite1, 1);

			monkeySprite2 = new CCSprite ("monkey");
			//	AddChild (monkeySprite2, 1);

			// Define actions
			var moveUp = new CCMoveBy (1.0f, new CCPoint (0.0f, 100.0f));
			var moveDown = moveUp.Reverse ();


			//	var moveForward = new CCTransitionMoveInR (0.1f,this);

			// A CCSequence action runs the list of actions in ... sequence!
			//CCFiniteTimeAction cfa = new CCEaseIn (moveUp);

			CCSequence moveSeq = new CCSequence (new CCEaseBackIn (moveUp), new CCEaseBackInOut (moveUp));

			repeatedAction = new CCRepeatForever (moveSeq);

			// A CCSpawn action runs the list of actions concurrently
			dreamAction = new CCSpawn (new CCFadeIn (5.0f), new CCWaves (5.0f, new CCGridSize (10, 20), 4, 4));

			//	CCAction moveR = new Action

			// Schedule for method to be called every 0.1s
			Schedule (UpdateLayerGradient, 0.1f);
		}

		void positionSprites ()
		{
			floorClone.AnchorPoint = CCPoint.AnchorMiddle;
			floorClone.Position = new CCPoint (160f, 440f);
			floorClone2.AnchorPoint = CCPoint.AnchorMiddle;
			floorClone2.Position = new CCPoint (160f, 160f);
			floorClone3.AnchorPoint = CCPoint.AnchorMiddle;
			floorClone3.Position = new CCPoint (520f, 440f);
			floorClone4.AnchorPoint = CCPoint.AnchorMiddle;
			floorClone4.Position = new CCPoint (520f, 160f);
			floorClone5.AnchorPoint = CCPoint.AnchorMiddle;
			floorClone5.Position = new CCPoint (880f, 440f);
			floorClone6.AnchorPoint = CCPoint.AnchorMiddle;
			floorClone6.Position = new CCPoint (880f, 160f);
			hero.PositionX = floorClone.PositionX - 2.5f;
			hero.PositionY = floorClone.PositionY + 2.5f;

			tunnel.AnchorPoint = CCPoint.AnchorMiddle;
			tunnel.Position = new CCPoint (320f, 460f);
			tunnel2.AnchorPoint = CCPoint.AnchorMiddle;
			tunnel2.Position = new CCPoint (320f, 180f);
			tunnel3.AnchorPoint = CCPoint.AnchorMiddle;
			tunnel3.Position = new CCPoint (680f, 460f);
			tunnel4.AnchorPoint = CCPoint.AnchorMiddle;
			tunnel4.Position = new CCPoint (680f, 180f);
		}

		protected override void AddedToScene ()
		{
			base.AddedToScene ();

			CCRect visibleBounds = VisibleBoundsWorldspace;
			XMaxValue = visibleBounds.MaxX;
			YMaxValue = visibleBounds.MaxY;

			XMinValue = visibleBounds.MinX;
			YMinValue = visibleBounds.MinY;

			CCPoint centerBounds = visibleBounds.Center;

			//CCPoint quarterWidthDelta = new CCPoint (visibleBounds.Size.Width / 4.0f, 0.0f);

			// Layout the positioning of sprites based on visibleBounds
			//monkeySprite1.AnchorPoint = CCPoint.AnchorMiddle;
			//	monkeySprite1.Position = centerBounds + quarterWidthDelta;

			//	monkeySprite2.AnchorPoint = CCPoint.AnchorMiddle;
			//	monkeySprite2.Position = centerBounds - quarterWidthDelta;

			//floorClone.AnchorPoint = CCPoint.AnchorUpperRight;

			positionSprites ();

			tunnel2.RotationX = tunnel2.RotationX - 180f;
			tunnel2.RotationY = tunnel2.RotationY - 180f;


			tunnel3.RotationX = tunnel3.RotationX - 90f;
			tunnel3.RotationY = tunnel3.RotationY - 90f;

			tunnel4.RotationX = tunnel4.RotationX - 270f;
			tunnel4.RotationY = tunnel4.RotationY - 270f;

			// Run actions on sprite
			// Note: we can reuse the same action definition on multiple sprites!
			//	monkeySprite1.RunAction (new CCSequence (dreamAction, repeatedAction));
			//	monkeySprite2.RunAction (new CCSequence (dreamAction, new CCDelayTime (0.5f), repeatedAction));

			//hero.RunAction (repeatedAction);

			// Create preloaded galaxy particle system  
			galaxySystem = new CCParticleGalaxy (centerBounds);

			// Customise default behaviour of predefined particle system
			galaxySystem.EmissionRate = 20.0f;
			galaxySystem.EndSize = 1.0f;
			galaxySystem.EndRadius = visibleBounds.Size.Width;
			galaxySystem.Life = 10.0f;
			galaxySystem.Color = CCColor3B.Red;

		//	AddChild (galaxySystem, 0);

			// Register to touch event
			var touchListener = new CCEventListenerTouchAllAtOnce ();
			touchListener.OnTouchesEnded = OnTouchesEnded;
			AddEventListener (touchListener, this);

		}

		protected void UpdateLayerGradient (float dt)
		{


			//hero moving logic
			float posX = hero.PositionX + heroMoveSpeedX;
			float posY = hero.PositionY + heroMoveSpeedY;

			if (posX > XMaxValue) {
				heroMoveSpeedX = -heroMoveSpeedX;
			} else if (posX < XMinValue) {
				heroMoveSpeedX = -heroMoveSpeedX;
			}
			if (posY > YMaxValue) {
				heroMoveSpeedY = -heroMoveSpeedY;
			} else if (posY < YMinValue) {
				heroMoveSpeedY = -heroMoveSpeedY;
			}

			//hero moves in a straight line
			hero.RunAction (new CCMoveTo (0.1f, new CCPoint (posX, posY)));


			//	CCColor3B startColor = this.StartColor;

			//	int newRedColor = startColor.R + redColorIncrement;
			//
			//	if (newRedColor <= byte.MinValue) {
			//		newRedColor = 0;
			//		redColorIncrement *= -1;
			//	} else if (newRedColor >= byte.MaxValue) {
			//		newRedColor = byte.MaxValue;
			//		redColorIncrement *= -1;
			//	}

			//	startColor.R = (byte)(newRedColor);

			//	StartColor = startColor;

			//
		

		}

		void OnTouchesEnded (List<CCTouch> touches, CCEvent touchEvent)
		{

			if (touches.Count > 0) {
				CCTouch touch = touches [0];
				CCPoint touchLocation = touch.Location;

				// Move particle system to touch location
				galaxySystem.StopAllActions ();
				galaxySystem.RunAction (new CCMoveTo (3.0f, touchLocation));

				tunnel.RotationX = tunnel.RotationX - 90f;
				tunnel.RotationY = tunnel.RotationY - 90f;


				tunnel2.RotationX = tunnel2.RotationX - 90f;
				tunnel2.RotationY = tunnel2.RotationY - 90f;


				tunnel3.RotationX = tunnel3.RotationX - 90f;
				tunnel3.RotationY = tunnel3.RotationY - 90f;

				tunnel4.RotationX = tunnel4.RotationX - 90f;
				tunnel4.RotationY = tunnel4.RotationY - 90f;

			}
		}
	}
}
