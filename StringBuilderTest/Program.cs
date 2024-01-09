// See https://aka.ms/new-console-template for more information
using System.Text;
using StringBuilderTest;

StringBuilderExtended sbx = new StringBuilderExtended(500);
StringBuilderExtended sbx2 = new StringBuilderExtended(500);
sbx.SetText("   \tDas sit ein Test   (sms) \n");
sbx.Substring(sbx2, 0, sbx.IndexOf("(sms"));
sbx2.Trim();
Console.WriteLine("-" + sbx2.ToString() + "-");

return;



