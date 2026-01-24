using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum Action
{
    [Display(Description = "الكل")] All,
    [Display(Description = "تسجيل دخول")] Login,

    [Display(Description = "إضافة مستخدم")]
    AddUser,

    [Display(Description = "تعديل مستخدم")]
    EditUser,
    [Display(Description = "حذف مستخدم")] DeleteUser,

    [Display(Description = "إضافة دور")] AddRole,
    [Display(Description = "تعديل دور")] EditRole,
    [Display(Description = "حذف دور")] DeleteRole,

    [Display(Description = "إضافة نوع منتج")] AddProductType,
    [Display(Description = "تعديل نوع منتج")] EditProductType,
    [Display(Description = "حذف نوع منتج")] DeleteProductType,

    [Display(Description = "إضافة مزود")] AddProvider,
    [Display(Description = "تعديل مزود")] EditProvider,
    [Display(Description = "حذف مزود")] DeleteProvider,

    [Display(Description = "إضافة طلب")] AddOrder,
    [Display(Description = "تعديل طلب")] EditOrder,
    [Display(Description = "تعديل حالة طلب")] EditOrderStatus,
    [Display(Description = "تعديل حالة الدفع لطلب")] EditOrderIsPaid,
    [Display(Description = "حذف طلب")] DeleteOrder,

    [Display(Description = "إضافة منتج")] AddProduct,
    [Display(Description = "تعديل منتج")] EditProduct,
    [Display(Description = "حذف منتج")] DeleteProduct,

    [Display(Description = "إضافة علامة منتج")] AddProductTag,
    [Display(Description = "تعديل علامة منتج")] EditProductTag,
    [Display(Description = "حذف علامة منتج")] DeleteProductTag,

    [Display(Description = "إضافة إعلان")] AddAd,
    [Display(Description = "تعديل إعلان")] EditAd,
    [Display(Description = "حذف إعلان")] DeleteAd,
}