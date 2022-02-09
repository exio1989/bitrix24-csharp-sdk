namespace Bitrix24ApiClient.src.Models
{
    /// <summary>
    /// Операторы взяты с https://dev.1c-bitrix.ru/learning/course/index.php?COURSE_ID=43&LESSON_ID=5753&LESSON_PATH=3913.3516.5748.5063.5753
    /// </summary>
    public enum FilterOperator
    {
        Equal = 0,
        GreateThan,
        LessThan,
        GreateThanOrEqual,
        LessThanOrEqual,
        InArray,
        NotInArray,
        Substring,
        NotEqual,
        NotSubstring,
        Like
    }
}
