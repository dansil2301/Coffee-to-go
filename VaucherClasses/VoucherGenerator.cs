using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_to_go
{
    internal class VoucherGenerator
    {
        private Voucher voucher = new Voucher();

        public void setVoucher(User user)
        {
            switch (user.GetCurrentStreak)
            {
                case >= 10:
                    user.voucherType = "Gold";
                    user.voucher = voucher.VoucherType["Gold"];
                    break;
                case >= 8:
                    user.voucherType = "Silver";
                    user.voucher = voucher.VoucherType["Silver"];
                    break;
                case >= 5:
                    user.voucherType = "Bronze";
                    user.voucher = voucher.VoucherType["Bronze"];
                    break;
            }
        }

        public bool isStreakBigEnough(User user)
        {
            return user.GetCurrentStreak >= 5 ? true : false;
        }

        public string GetVoucherNameByStreak(User user)
        {
            switch (user.GetCurrentStreak)
            {
                case >= 10:
                    return "Gold";
                    break;
                case >= 8:
                    return "Silver";
                    break;
                case >= 5:
                    return "Bronze";
                    break;
            }

            return "";
        }

        public void SetVaucher(User user, string voucherType)
        {
            user.voucherType = voucherType;
            user.voucher = voucher.VoucherType[voucherType];
        }
    }
}
