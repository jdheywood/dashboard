using System;

namespace Dashboard.Core.Contracts
{
    public interface IConfigurationRepository
    {
        TReference GetComplexSetting<TReference>(string settingName) where TReference : class;

        TValue GetSimpleSetting<TValue>(string settingName) where TValue : IConvertible;

        TValue GetSimpleSettingOrDefault<TValue>(string settingName, Func<TValue> defaultValue)
            where TValue : IConvertible;
    }

}
