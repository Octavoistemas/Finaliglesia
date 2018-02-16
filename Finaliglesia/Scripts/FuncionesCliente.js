var miembrosItems = new Listas();

function agregarmiembros_click() {
    var isValidItem = true;
    
    miembrosItems.Agregar({
         MiembroID:0,
     Cedula: $('#Cedula').val().trim(),
     Nombre:$('#Nombre').val().trim(),
     Apellido:$('#Apellido').val().trim(),
     Direccion: $('#Direccion').val().trim(),
     Celular: $('#Celular').val().trim(),
     Telefono:$('#Telefono').val().trim(),
     genero: $('#genero').val().trim(),
     FechaNacimiento: $('#Fecha').val().trim(),
     email: $('#email').val().trim(),
     Rol: $('#Rol').val().trim()
        });
        $('#Cedula').val('').focus();
        $('#Nombre').val('');
        $('#Apellido').val('');
        $('#Direccion').val('');
        $('#Celular').val('');
        $('#Telefono').val('');
        $('#genero').val('');
        $('#Fecha').val('');
        $('#email').val('');
        $('#Rol').val('');
        
    //falta codigo para limpiar cajas
        MostrarMiembros(true);
}

function MostrarMiembros(editar) {
    $('#miembros').html('');
    if (miembrosItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped table-responsive"/>');
        if (editar){
            $table.append('<thead><tr><th>Cedula</th><th>Nombre</th><th>Apellido</th><th>Direccion</th><th>Celular</th><th>Telefono</th><th>Genero</th><th>Fecha de Nacimiento</th><th>Correo electronico</th><th>Rol</th></tr></thead>')
        }
        else {
           
            $table.append('<thead><tr><th>Cedula</th><th>Nombre</th><th>Apellido</th><th>Direccion</th><th>Celular</th><th>Telefono</th><th>Genero</th><th>Fecha de Nacimiento</th><th>Correo electronico</th><th>Rol</th></tr></thead>')
        }
        var $tbody = $('<tbody/>');
        for (var i = 0; i < miembrosItems.Total() ; i++) {
           
            var $row = $('<tr/>');
            $row.append($('<td/>').html(miembrosItems.Item(i).Cedula));
            $row.append($('<td/>').html(miembrosItems.Item(i).Nombre));
            $row.append($('<td/>').html(miembrosItems.Item(i).Apellido));
            $row.append($('<td/>').html(miembrosItems.Item(i).Direccion));
            $row.append($('<td/>').html(miembrosItems.Item(i).Celular));
            $row.append($('<td/>').html(miembrosItems.Item(i).Telefono));
            $row.append($('<td/>').html(miembrosItems.Item(i).genero));
            $row.append($('<td/>').html(miembrosItems.Item(i).FechaNacimiento));
            $row.append($('<td/>').html(miembrosItems.Item(i).email));
            $row.append($('<td/>').html(miembrosItems.Item(i).Rol));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarMiembro(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#miembros').html($table);
    }
}

function EliminarMiembro(indice) {
    miembrosItems.Eliminar(indice);
    MostrarMiembros(true);
    return false;

}



function crear_Click() {
   var isAllValid = true;
   if (isAllValid) {
       var data = {
           MiemrboCeremoniaID: 0,
           CeremoniasId: $('#CeremoniasId').val().trim(),
           Miembros: miembrosItems.lista
       }
       
       var token = $('[name=__RequestVerificationToken]').val();
       
       $.ajax({
           url: '/MiembroCeremonias/Create',
           type: "POST",
           data: { __RequestVerificationToken: token, miembroCeremonia: data },
           success: function (d) {
               if (d == true) {
                   window.location.href = "/Ceremonias/Index";
               } else {
                   alert('Hubo un error al momento de guardar');
               }
           },
           error: function (d) {
               alert('Error, intente nuevamente');
           }
       });
   }
}

function modificar_Click() {
    var isAllValid = true;
    if ($('#Nombre').val().trim() == '') {
        isAllValid = false;
        $('#Nombre').siblings('span.error').css('visibility', 'visible');
        $('#Nombre').siblings('span.error').css('color', 'red');
    }
    else {
        $('#Nombre').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#TipoClienteId').val().trim() == '') {
        isAllValid = false;
        $('#TipoClienteId').siblings('span.error').css('visibility', 'visible');
        $('#TipoClienteId').siblings('span.error').css('color', 'red');
    }
    else {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        var data = {
            ClienteID: 0,
            Nombre: $('#Nombre').val().trim(),
            TipoClienteId: $('#TipoClienteId').val().trim(),
            RFC: $('#RFC').val().trim(),
            TipoPersonaSat: $('#TipoPersonaSat').val().trim(),
            Telefono: telItems.lista,
            Correos: emailItems.lista,
            Direcciones: direccionesItem.lista
        }

        var token = $('[name=__RequestVerificationToken]').val();
        var idCliente = $('#ClienteID').val().trim();
        var url = 'Clientes/Edit' + idCliente;
        $.ajax({
            url: url,
            type: "POST",
            data: { __RequestVerificationToken: token, cliente: data },
            success: function (d) {
                if (d == true) {
                    window.location.href = "/Clientes/Index";
                } else {
                    alert('Hubo un error al momento de guardar');
                }
            },
            error: function (d) {
                alert('Error, intente nuevamente');
            }
        });
    }
}