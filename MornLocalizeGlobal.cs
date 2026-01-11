using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MornLib
{
    [CreateAssetMenu(fileName = nameof(MornLocalizeGlobal), menuName = "Morn/" + nameof(MornLocalizeGlobal))]
    public sealed class MornLocalizeGlobal : MornGlobalBase<MornLocalizeGlobal>
    {
        public override string ModuleName => "MornLocalize";
        [SerializeField] private MornLocalizeSettings _settings;
        [SerializeField] private string _debugLanguageKey = "jp";
        public MornLocalizeSettings Settings => _settings;
        internal string DebugLanguageKey => _debugLanguageKey;

        public static void OpenMasterData()
        {
            I.Settings.Open();
        }

        public async static UniTask UpdateMasterDataAsync(CancellationToken ct = default)
        {
            await I.Settings.UpdateAsync();
        }

        internal static void Log(string message)
        {
            I.LogInternal(message);
        }

        internal static void LogWarning(string message)
        {
            I.LogWarningInternal(message);
        }

        internal static void LogError(string message)
        {
            I.LogErrorInternal(message);
        }

        internal static void SetDirty(Object obj)
        {
            I.SetDirtyInternal(obj);
        }
    }
}