// See https://aka.ms/new-console-template for more information
using System.Text;

StringBuilderExtended sbx = new StringBuilderExtended(500);
StringBuilderExtended sbx2 = new StringBuilderExtended(500);
sbx.SetText("   \tDas sit ein Test   (sms) \n");
sbx.Substring(sbx2, 0, sbx.IndexOf("(sms"));
sbx2.Trim();
Console.WriteLine("-" + sbx2.ToString() + "-");

return;



public class StringBuilderExtended
{
    private StringBuilder sb;
    public StringBuilderExtended(int size) { sb = new StringBuilder(size); }
    public StringBuilder GetSB() { return sb; }
    public override string ToString() { return sb.ToString(); }
    public void Trim()
    {
        int wsFromBegin = 0;
        int wsFromEnd = 0;
        for (int i = sb.Length - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(sb[i])) wsFromEnd++;
            else break;
        }
        for (int i = 0; i < sb.Length; i++)
        {
            if (char.IsWhiteSpace(sb[i])) wsFromBegin++;
            else break;
        }
        sb.Remove(0, wsFromBegin);
        sb.Remove(sb.Length - wsFromEnd, wsFromEnd);
    }
    public void Substring(StringBuilderExtended targetSBX, int startindex, int lenght = -1)
    {
        Substring(targetSBX.sb, startindex, lenght);
    }
    public void Substring(StringBuilder targetSB, int startindex, int lenght = -1)
    {
        targetSB.Clear();
        if (startindex > sb.Length) return;
        int endindex;
        if (lenght > 0) endindex = startindex + lenght - 1;
        else endindex = sb.Length - 1;
        for (int i = startindex; i <= endindex; i++) targetSB.Append(sb[i]);
    }
    public void SetText(string text) { sb.Clear(); sb.Append(text); }
    public void ToLower() { for (int i = 0; i < sb.Length; i++) sb[i] = char.ToLower(sb[i]); }
    public bool Contains(string s) { return IndexOf(s) != -1; }
    public int IndexOf(string s)
    {
        int sIndex = 0;
        int contains = 0;
        int findIndex = -1;
        for (int i = 0; sIndex < s.Length && i < sb.Length && i + (s.Length - sIndex) < sb.Length; i++, sIndex += contains)
        {
            if (sb[i] == s[sIndex])
            {
                if (contains == 0) findIndex = i;
                contains = 1;
            }
            else { contains = 0; sIndex = 0; findIndex = -1; }
        }
        if (sIndex < s.Length - 1) findIndex = -1;
        return findIndex;
    }

}
