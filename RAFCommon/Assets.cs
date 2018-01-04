using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RAFCommon
{
    public class Assets
    {
        private static string _CCxp = @"^(?:[24563][0-9]{10,15})\ [0-9]{2}/[0-9]{2}";
        //@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})\-[0-9]{4}"
        private static string _CCMask_RepRx = @"^[24563][0-9]{6,10}([0-9]{4})\ ([0-9]{2})/([0-9]{2})";
        private static string _CCStore_RepRx = @"^([24563][0-9]{10,15})\ ([0-9]{2})/([0-9]{2})";
        
        public static string AssetGenStoredAssetNum(int assetType, string assetNum)
        {
            string storedAssetNum = assetNum;
            try
            {
                switch (assetType)
                {
                    case 300:
                    case 400:
                        {
                            Regex xp = new Regex(_CCxp);
                            if (xp.IsMatch(assetNum))
                            {
                                storedAssetNum = Regex.Replace(assetNum, _CCStore_RepRx, "$1-$2$3");
                                storedAssetNum = RAFCrypto.Common.GetMD5(assetNum);
                            }
                            break;
                        }
                    default:
                        {
                            storedAssetNum = assetNum;
                            break;
                        }
                }
            }
            catch (System.Exception x)
            {
                x.Message.Trim();
            }
            return storedAssetNum;
        }



        public static string AssetGenDisplayMask(int assetType, string assetNum)
        {
            string mask = assetNum;
            try
            {
                switch (assetType)
                {
                    //Credit & Debit Cards 
                    case 300:
                    case 400:
                        {
                            //371449635398431-0910

                            Regex xp = new Regex(_CCxp);
                            if (xp.IsMatch(assetNum))
                            {
                                mask = Regex.Replace(assetNum, _CCMask_RepRx, "**********$1 $2/$3");
                            }
                            break;
                        }
                    default:
                        {
                            mask = assetNum;
                            break;
                        }
                }
            }
            catch(System.Exception x)
            {
                x.Message.Trim();
            }
            return mask;
        }



    }
}
