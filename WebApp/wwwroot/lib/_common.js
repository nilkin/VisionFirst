function removeItem(_id, _name, _path, elem) {
   
    swal({
        title: `Diqqət`,
        text: `Əminsiniz ki, '${_name}' siyahıdan silinsin?`,
        icon: "warning",
        buttons: ["Xeyr", "Bəli"],
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'get',
                url: _path,
                datatype: 'json',
                data: { id: _id },
                success: function (response) {
                    if (response.error == true) {
                        toastr.error(response, "Xəta!");
                        return;
                    }
                    toastr.success(response, "Uğur!");
                    $(elem).parent().closest("tr").remove();
                },
                error: function (response) {
                    toastr.error("Gözlənilməz xəta baş verdi", "Xəta!");
                }
            });
        }
    });
}
