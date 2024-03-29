﻿namespace Bitrix24RestApiClient.Core.Models.Enums
{
    public enum StatusSemanticIdEnum
    {
        Failed = 0,     /// F (failed) - обработан неуспешно,
        Success = 1,     /// S (success) - обработан успешно,
        Processing = 2   /// P (processing) - лид в обработке.
    }
}
