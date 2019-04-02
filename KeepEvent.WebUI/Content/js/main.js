function ajaxGetir() {
      $.ajax({
          url: "/AJAX/Categories",
        type: "GET",
          success: function (veri) {
              $.each(veri, function (index, item) {
                
                  $(".category").append("<option value='"+item.ID+"'>" + item.Name + "</option>");
              })
        },
        error: function (hata) { alert(hata.responseText) }
    });
}

function GetSubCategory(sc) {
    $.ajax({
        url: "/AJAX/Categoriess",
        type: "GET",
        data: { "cID": $(sc).val() },
        success: function (veri) {
            $(".subcategories").empty();
            $(".subcategories").append("<option value='0'>Alt Kategori Seçiniz</option>");
            $.each(veri, function (index, item) {                
                $(".subcategories").append("<option value='" + item.ID + "'>" + item.Name + "</option>");
            })
        },
        error: function (hata) { alert(hata.responseText) }
    });
}





//function GetSubCategory(sc) {
//    $.ajax({
//        url: "/AJAX/SubCategories",
//        type: "GET",
//        data: { "CategoryID": $(sc).val() },
//        success: function (veri) {
//            $(".subcategories").empty();
//            $(".subcategories").append("<option value='0'>Alt Kategori Seçiniz</option>");
//            $.each(veri, function (index, item) {                
//                $(".subcategories").append("<option value='" + item.ID + "'>" + item.Name + "</option>");
//            })
//        },
//        error: function (hata) { alert(hata.responseText) }
//    });
//}
