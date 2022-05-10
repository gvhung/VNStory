using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace VNStory.Web.Commons
{
    public sealed class Globals
    {
        private static readonly string[] VietnameseSigns = new string[] { "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ" };

        private static string _applicationPath;
        private static string _applicationMapPath;

        /// <summary>
        /// Gets the application path.
        /// </summary>
        public static string ApplicationPath
        {
            get
            {
                if (_applicationPath == null && (HttpContext.Current != null))
                {
                    _applicationPath = HttpContext.Current.Request.ApplicationPath.ToLowerInvariant();
                }

                return _applicationPath;
            }
        }

        /// <summary>
        /// Gets or sets the application map path.
        /// </summary>
        /// <value>
        /// The application map path.
        /// </value>
        public static string ApplicationMapPath
        {
            get
            {
                return _applicationMapPath ?? (_applicationMapPath = System.AppDomain.CurrentDomain.BaseDirectory.Substring(0, System.AppDomain.CurrentDomain.BaseDirectory.Length - 1).Replace("/", "\\"));
            }
        }

        /// <summary>
        /// Gets Upload folder path.
        /// </summary>
        /// <value>
        /// The application map path.
        /// </value>
        public static string UploadFolderMapPath
        {
            get
            {
                return System.IO.Path.Combine(ApplicationMapPath, "Uploads");
            }
        }

        /// <summary>
        /// Cloaks the text, obfuscate sensitive data to prevent collection by robots and spiders and crawlers
        /// </summary>
        /// <param name="PersonalInfo">The personal info.</param>
        /// <returns>obfuscated sensitive data by hustling ASCII characters</returns>
        public static string CloakText(string PersonalInfo)
        {
            if (PersonalInfo == null)
            {
                return string.Empty;
            }

            const string Script = @"
                <script type=""text/javascript"">
                    //<![CDATA[
                        document.write(String.fromCharCode({0}))
                    //]]>
                </script>
            ";

            var characterCodes = PersonalInfo.Select(ch => ((int)ch).ToString(CultureInfo.InvariantCulture));
            return string.Format(Script, string.Join(",", characterCodes.ToArray()));
        }

        /// <summary>
        /// Adds the port.
        /// </summary>
        /// <param name="httpAlias">The HTTP alias.</param>
        /// <param name="originalUrl">The original URL.</param>
        /// <returns>url with port if the post number is not 80</returns>
        public static string AddPort(string httpAlias, string originalUrl)
        {
            var uri = new Uri(originalUrl);
            var aliasUri = new Uri(httpAlias);

            if (!uri.IsDefaultPort)
            {
                httpAlias = AddHTTP(aliasUri.Host + ":" + uri.Port + aliasUri.LocalPath);
            }

            return httpAlias;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds HTTP to URL if no other protocol specified
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="strURL">The url</param>
        /// <returns>The formatted url</returns>
        /// -----------------------------------------------------------------------------
        public static string AddHTTP(string strURL)
        {
            if (!String.IsNullOrEmpty(strURL))
            {
                if (strURL.IndexOf("mailto:") == -1 && strURL.IndexOf("://") == -1 && strURL.IndexOf("~") == -1 && strURL.IndexOf("\\\\") == -1)
                {
                    if (HttpContext.Current != null && HttpContext.Current.Request.IsSecureConnection)
                    {
                        strURL = "https://" + strURL;
                    }
                    else
                    {
                        strURL = "http://" + strURL;
                    }
                }
            }
            return strURL;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Generates the correctly formatted url
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="url">The url to format.</param>
        /// <returns>The formatted (resolved) url</returns>
        /// -----------------------------------------------------------------------------
        public static string ResolveUrl(string url)
        {
            // String is Empty, just return Url
            if (String.IsNullOrEmpty(url))
            {
                return url;
            }
            // String does not contain a ~, so just return Url
            if ((url.StartsWith("~") == false))
            {
                return url;
            }
            // There is just the ~ in the Url, return the appPath
            if ((url.Length == 1))
            {
                return ApplicationPath;
            }
            if ((url.ToCharArray()[1] == '/' || url.ToCharArray()[1] == '\\'))
            {
                // Url looks like ~/ or ~\
                if (!string.IsNullOrEmpty(ApplicationPath) && ApplicationPath.Length > 1)
                {
                    return ApplicationPath + "/" + url.Substring(2);
                }
                else
                {
                    return "/" + url.Substring(2);
                }
            }
            else
            {
                // Url look like ~something
                if (!string.IsNullOrEmpty(ApplicationPath) && ApplicationPath.Length > 1)
                {
                    return ApplicationPath + "/" + url.Substring(1);
                }
                else
                {
                    return ApplicationPath + url.Substring(1);
                }
            }
        }

        public static System.IO.MemoryStream StreamToMemory(string path)
        {

            System.IO.FileStream input = default(System.IO.FileStream);
            System.IO.MemoryStream output = default(System.IO.MemoryStream);

            input = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            output = StreamToMemory(input);
            input.Close();

            return output;

        }

        public static System.IO.MemoryStream StreamToMemory(System.IO.Stream input)
        {

            byte[] buffer = new byte[1024];
            int count = 1024;
            System.IO.MemoryStream output = default(System.IO.MemoryStream);

            // build a new stream
            if (input.CanSeek)
            {
                output = new System.IO.MemoryStream((int)input.Length);
            }
            else
            {
                output = new System.IO.MemoryStream();
            }

            do
            {
                count = input.Read(buffer, 0, count);
                if (count == 0)
                    break; // TODO: might not be correct. Was : Exit Do
                output.Write(buffer, 0, count);
            } while (true);

            // rewind stream
            output.Position = 0;

            // pass back
            return output;

        }

        public static string FormatFileSize(long Bytes)
        {
            Decimal size = 0;
            string result;

            if (Bytes >= 1073741824)
            {
                size = Decimal.Divide(Bytes, 1073741824);
                result =
                    String.Format(
                        CultureInfo.InvariantCulture,
                        "{0:##.##} gb",
                        size);
            }
            else if (Bytes >= 1048576)
            {
                size = Decimal.Divide(Bytes, 1048576);
                result =
                    String.Format(
                        CultureInfo.InvariantCulture,
                        "{0:##.##} mb",
                        size);
            }
            else if (Bytes >= 1024)
            {
                size = Decimal.Divide(Bytes, 1024);
                result =
                    String.Format(
                        CultureInfo.InvariantCulture,
                        "{0:##.##} kb",
                        size);
            }
            else if (Bytes > 0 & Bytes < 1024)
            {
                size = Bytes;
                result =
                    String.Format(
                        CultureInfo.InvariantCulture,
                        "{0:##.##} bytes",
                        size);
            }
            else
            {
                result = "0 bytes";
            }

            return result;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The GetTotalRecords method gets the number of Records returned.
        /// </summary>
        /// <param name="dr">An <see cref="IDataReader"/> containing the Total no of records</param>
        /// <returns>An Integer</returns>
        /// -----------------------------------------------------------------------------
        public static int GetTotalRecords(ref IDataReader dr)
        {
            int total = 0;
            if (dr.Read())
            {
                try
                {
                    total = Convert.ToInt32(dr["TotalRecords"]);
                }
                catch (Exception ex)
                {
                    total = -1;
                }
            }
            return total;
        }


        public static string CreateSlug(string vInput)
        {
            return RemoveIllegalCharacters(vInput);
        }

        public static string RemoveUnicodeChar(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public static string RemoveIllegalCharacters(string vInput)
        {

            if (string.IsNullOrEmpty(vInput) == false)
            {
                vInput = vInput.Trim();

                vInput = RemoveUnicodeChar(vInput);

                vInput = vInput.Replace("Ф", string.Empty);
                // Ф &#1060;
                vInput = vInput.Replace("&#1060;", string.Empty);
                // Ф 
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(33).ToString(), string.Empty);
                // !
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(34).ToString(), string.Empty);
                // "
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(35).ToString(), string.Empty);
                // #
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(36).ToString(), string.Empty);
                // $
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(37).ToString(), string.Empty);
                // %
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(38).ToString(), string.Empty);
                // &
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(39).ToString(), string.Empty);
                // '
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(40).ToString(), string.Empty);
                // (
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(41).ToString(), string.Empty);
                // )
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(42).ToString(), string.Empty);
                // *
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(43).ToString(), string.Empty);
                // +
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(44).ToString(), string.Empty);
                // ,
                //vInput = vInput.Replace(Chr(45), String.Empty)   ' -
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(46).ToString(), string.Empty);
                // .
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(47).ToString(), string.Empty);
                // /

                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(58).ToString(), string.Empty);
                // :
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(59).ToString(), string.Empty);
                // ;
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(60).ToString(), string.Empty);
                // <
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(61).ToString(), string.Empty);
                // =
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(62).ToString(), string.Empty);
                // >
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(63).ToString(), string.Empty);
                // ?
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(64).ToString(), string.Empty);
                // @

                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(91).ToString(), string.Empty);
                // [
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(92).ToString(), string.Empty);
                // \
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(93).ToString(), string.Empty);
                // ]
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(94).ToString(), string.Empty);
                // ^
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(95).ToString(), string.Empty);
                // _
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(96).ToString(), string.Empty);
                // `

                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(123).ToString(), string.Empty);
                // {
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(124).ToString(), string.Empty);
                // |
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(125).ToString(), string.Empty);
                // }
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(126).ToString(), string.Empty);
                // ~

                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(9).ToString(), string.Empty);
                //Remove Tabs
                vInput = vInput.Replace(Microsoft.VisualBasic.Strings.Chr(32), Microsoft.VisualBasic.Strings.Chr(45));
                // Spase -> -
                vInput = vInput.Replace("–", string.Empty);
                vInput = vInput.Replace("“", string.Empty);
                vInput = vInput.Replace("”", string.Empty);
                vInput = vInput.Replace("‘", string.Empty);
                vInput = vInput.Replace("’", string.Empty);
                vInput = RemoveDiacritics(vInput);
                vInput = RemoveExtraHyphen(vInput);

            }
            return vInput;
        }

        public static string RemoveExtraHyphen(string text)
        {
            if (text.Contains("--"))
            {
                text = text.Replace("--", "-");
                return RemoveExtraHyphen(text);
            }
            return text;
        }

        public static string RemoveDiacritics(string vInput)
        {
            string normalized = vInput.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i <= normalized.Length - 1; i++)
            {
                char c = normalized[i];
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }


    }

}