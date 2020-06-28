using System.Text;
using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class Challenge02
{
    public static string MarkdownParser(string markdown)
    {

        int numhash = 0;

        if (markdown != null)
        {
        
            bool bWhiteSpaces = false;
            for (int i=0;i<markdown.Length;i++)
            {
                if (markdown[i] == ' ')
                {
                    bWhiteSpaces = true;

                }
                else if (markdown[i] == '#' && bWhiteSpaces == true)
                {
                    markdown = markdown.Substring(i, markdown.Length - i);
                    break;
                }
                else if (markdown[i] == '#' )
                    break;
                else if (markdown[i] != '#' && markdown[i] != ' ')
                    break;
            }

            var reg = new Regex(@"^[#]{1,6}[ ]{1}");
            if (!reg.Match(markdown.ToString()).Success)
            {
                return markdown;
            }
            for (int i = 0; i < markdown.Length; i++)
            {
                if (markdown[i] == '#')
                {
                    numhash++;
                }
                else
                {


                    StringBuilder tmp2 = new StringBuilder(string.Empty);
               //     tmp2.Append(markdown[j]);
                    return "<h" + numhash + ">" + tmp2 + "</h" + numhash + ">";
                }

            }



        }
        return null;

    }
    public static string MarkdownParserBueno(string markdown)
    {

        int numhash = 0;

        if (markdown != null)
        {
            bool bFound = false;
            bool bWrongInput = false;
            for (int i = 0; i < markdown.Length; i++)
            {
                StringBuilder tmp2 = new StringBuilder(string.Empty); 
                if (bWrongInput)
                {
                    return markdown;
                }
                else if (markdown[i] != '#' && markdown[i] != ' ')
                {
                    bWrongInput = true;
                }
                else if (markdown[i] == '#')
                {
                    bFound = true;
                    numhash++;
                }
                else if (bFound && markdown[i] != '#' && (numhash <= 6  && numhash > 0) && !bWrongInput)
                {
                        for (int j = i + 1; j < markdown.Length; j++)
                        {
                            tmp2.Append(markdown[j]);
                        }
                        return "<h" + numhash + ">" + tmp2 + "</h" + numhash + ">";
                        
                }
                else
                    return markdown;


            }



        }
        return null;

    }
    public static string MarkdownParserOld( string markdown )
  {

            int numhash = 0;
    
            Console.WriteLine(markdown);
            if (markdown!= null)
            {
             StringBuilder tmp2 = new StringBuilder(string.Empty); ;
                int i = 0;
                 bool bFound = false;
                 bool bWrong = false;
                for (i = 0; i < markdown.Length; i++)
                {
                    if (markdown[i] == '#')
                    {
                        bFound = true;
                        numhash++;
                    }
                    else if (bFound)
                        break;
                    else if (markdown[i] != ' ')
                    {
                        bWrong = true;
                        break;
                    }
                }
                if (markdown[i] == ' ' && numhash <= 6 && !bWrong)
                {
                    for (int j = i + 1; j < markdown.Length; j++)
                    {
                        tmp2.Append(markdown[j]);
                    }
                    return "<h" + numhash + ">" + tmp2 + "</h" + numhash + ">";
                }
                else
                    return markdown;
            }
            return null;

  }
}