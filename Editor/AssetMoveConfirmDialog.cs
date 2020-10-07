using System;
using UnityEditor;

namespace Kogane.Internal
{
	internal sealed class AssetMoveConfirmDialog : UnityEditor.AssetModificationProcessor
	{
		private static bool m_isAllMove;

		private static AssetMoveResult OnWillMoveAsset
		(
			string sourcePath,
			string destinationPath
		)
		{
			var settings = AssetMoveConfirmDialogSettings.GetInstance();

			if ( !settings.Enabled ) return AssetMoveResult.DidNotMove;
			if ( m_isAllMove ) return AssetMoveResult.DidNotMove;

			var index = EditorUtility.DisplayDialogComplex
			(
				title: "UniAssetMoveConfirmDialog",
				message: $"「{sourcePath}」を「{destinationPath}」に移動しますか？",
				ok: "はい",
				cancel: "いいえ",
				alt: "すべて移動"
			);

			switch ( index )
			{
				case 0: return AssetMoveResult.DidNotMove;
				case 1: return AssetMoveResult.FailedMove;
				case 2:
				{
					m_isAllMove                 =  true;
					EditorApplication.delayCall += () => m_isAllMove = false;
					return AssetMoveResult.DidNotMove;
				}
			}

			throw new InvalidOperationException();
		}
	}
}