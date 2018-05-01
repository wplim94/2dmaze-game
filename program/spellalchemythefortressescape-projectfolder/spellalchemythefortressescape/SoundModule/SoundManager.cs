using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using SpellAlchemyTheFortressEscape.StaticObjectModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellAlchemyTheFortressEscape.SoundModule
{
    public class SoundManager
    {
        public SoundEffect buttonSound;
        public SoundEffect gameOverSound;
        public SoundEffect getItemSound;
        public SoundEffect footstepSound;
        public SoundEffect unlockDoorSound;
        public SoundEffect hitByMinionSound;
        public SoundEffect hitByWizardSound;
        public SoundEffect recoverHPSound;
        public SoundEffect BGMSound;
        public SoundEffect winningSound;
        public SoundEffectInstance BGMInstance;
        public SoundEffectInstance GameOverBGMInstance;

        public SoundManager(ContentManager Content)
        {
            buttonSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\ButtonSFX");
            gameOverSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\GameOverSFX");
            getItemSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\GetItemSFX");
            footstepSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\FootstepSFX");
            BGMSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\Tombi_Dwarf_Forest_BGM");
            unlockDoorSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\UnlockDoorSFX");
            winningSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\Winning");
            hitByWizardSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\HitByWizardSFX");
            hitByMinionSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\HitByMinionSFX");
            recoverHPSound = Content.Load<SoundEffect>(@"Resources\MusicAndSFX\HPRecoverySFX");

        }

        public void PlayBGM()
        {
          
            BGMInstance = BGMSound.CreateInstance();
            BGMInstance.IsLooped = true;
            BGMInstance.Play();
                   
        }

        public void PlayFootstepSound()
        {
            footstepSound.Play(0.15f, 0.0f, 0.0f);
        }

        public void PlayUnlockDoorSound()
        {
            unlockDoorSound.Play(0.15f, 0.0f, 0.0f);         
        }

        public void PlayHidingSound()
        {
            
           buttonSound.Play(0.30f, 0.0f, 0.0f);
               
        }

        public void PlayPickUpSound()
        {
           getItemSound.Play();
        }

        public void PlayHitByMinionSound()
        {
            hitByMinionSound.Play();
        }

        public void PlayHitByWizardSound()
        {
            hitByWizardSound.Play();
        }

        public void PlayRecoverHPSound()
        {
            recoverHPSound.Play();
        }

        public void PlayWinningSound()
        {
            winningSound.Play();
        }

        public void PlayGameOverSound()
        {
            BGMInstance.Stop();
            GameOverBGMInstance = gameOverSound.CreateInstance();
            GameOverBGMInstance.IsLooped = true;
            GameOverBGMInstance.Play();
        }

        public void StopGameOverSound()
        {
            GameOverBGMInstance.Stop();
        }

        public void StopBGM()
        {
            BGMInstance.Stop();
        }
    }
}
