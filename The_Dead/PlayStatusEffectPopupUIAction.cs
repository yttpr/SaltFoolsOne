// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PlayStatusEffectPopupUIAction
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections;
using UnityEngine;

namespace THE_DEAD
{
  public class PlayStatusEffectPopupUIAction : CombatAction
  {
    public int _id;
    public bool _isUnitCharacter;
    public int _amount;
    public StatusEffectInfoSO _status;
    public StatusFieldEffectPopUpType _popUpType;

    public PlayStatusEffectPopupUIAction(
      int id,
      bool isUnitCharacter,
      int amount,
      StatusEffectInfoSO status,
      StatusFieldEffectPopUpType popUpType)
    {
      this._id = id;
      this._isUnitCharacter = isUnitCharacter;
      this._amount = amount;
      this._status = status;
      this._popUpType = popUpType;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      Vector3 vector;
      if (this._isUnitCharacter)
      {
        CharacterCombatUIInfo character;
        stats.combatUI._charactersInCombat.TryGetValue(this._id, out character);
        vector = stats.combatUI._characterZone.GetCharacterPosition(character.FieldID);
        stats.combatUI.PlaySoundOnPosition(this._status.UpdatedSoundEvent, vector);
        int ppu = 32;
        Sprite sprite = Sprite.Create(this._status.icon.texture, new Rect(0.0f, 0.0f, (float) this._status.icon.texture.width, (float) this._status.icon.texture.height), new Vector2(0.5f, 0.5f), (float) ppu);
        yield return (object) stats.combatUI._popUpHandler3D.StartStatusFieldShowcase(false, vector, this._popUpType, this._amount, sprite);
        sprite = (Sprite) null;
      }
      else
      {
        EnemyCombatUIInfo enemy;
        stats.combatUI._enemiesInCombat.TryGetValue(this._id, out enemy);
        vector = stats.combatUI._enemyZone.GetEnemyPosition(enemy.FieldID);
        stats.combatUI.PlaySoundOnPosition(this._status.UpdatedSoundEvent, vector);
        int ppu = 32;
        Sprite sprite = Sprite.Create(this._status.icon.texture, new Rect(0.0f, 0.0f, (float) this._status.icon.texture.width, (float) this._status.icon.texture.height), new Vector2(0.5f, 0.5f), (float) ppu);
        yield return (object) stats.combatUI._popUpHandler3D.StartStatusFieldShowcase(true, vector, this._popUpType, this._amount, sprite);
        sprite = (Sprite) null;
      }
    }
  }
}
