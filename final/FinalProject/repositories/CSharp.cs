
public class CSharp: ScriptingLanguage
{
    public CSharp()
    {
        UpdateClassFormat(new string[]{"\nACCESS_MODIFIER CONTROL_TYPE class CLASS_NAME{ : PARENT_CLASS}\n{", "\n}"});
        UpdateMethodFormat(new string[]{"\nACCESS_MODIFIER CONTROL_TYPE RETURN_TYPE METHOD_NAME(PARAMS)\n{", "\n}"});
        UpdateAttributeFormat("\nACCESS_MODIFIER TYPE ATTRIBUTE_NAME{INITIALIZE_WITH_VALUE};");
        UpdateMethodLineFormat("\nLINE_CONTENT");
        UpdateMethodBlockFormat("if", new string[]{"\nif (EXPRESSION)\n{", "\n}"});
        UpdateMethodBlockFormat("else if", new string[]{"\nelse if (EXPRESSION)\n{", "\n}"});
        UpdateMethodBlockFormat("else", new string[]{"\nelse\n{", "\n}"});
        UpdateMethodBlockFormat("switch", new string[]{"\nswitch(EXPRESSION)\n{", "\n}"});
        UpdateMethodBlockFormat("case", new string[]{"\ncase CASE_VALUE:", ""});
        UpdateMethodBlockFormat("do", new string[]{"\ndo\n{", "\n}"});
        UpdateMethodBlockFormat("do while", new string[]{"\nwhile(EXPRESSION);", ""});
        UpdateMethodBlockFormat("while", new string[]{"\nwhile(EXPRESSION)\n{", "\n}"});
        UpdateMethodBlockFormat("try", new string[]{"\ntry\n{", "\n}"});
        UpdateMethodBlockFormat("catch", new string[]{"\ncatch(PARAMS)\n{", "\n}"});
        UpdateMethodBlockFormat("for", new string[]{"\nfor (VARIABLE_DECLARATION; EXPRESSION; INCREMENT_STATEMENT)\n{", "\n}"});
        UpdateMethodBlockFormat("foreach", new string[]{"\nforeach (VARIABLE_TYPE VARIABLE_NAME in LIST)\n{", "\n}"});
    }
    
}