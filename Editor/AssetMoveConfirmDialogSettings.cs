using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
	internal sealed class AssetMoveConfirmDialogSettings :
		ScriptableObjectForPreferences<AssetMoveConfirmDialogSettings>
	{
		[SerializeField] private bool m_enabled = false;

		public bool Enabled => m_enabled;

		[SettingsProvider]
		private static SettingsProvider SettingsProvider()
		{
			return CreateSettingsProvider( "Kogane/UniAssetMoveConfirmDialog" );
		}
	}
}