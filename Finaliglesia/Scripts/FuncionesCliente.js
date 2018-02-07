var telItems = new Listas();
var emailItems = new Listas();
var direccionesItem = new Listas();

function addTel_Click() { 
    var isValidItem = true;
    if ($('#Telefono').val().trim() == '') {
        isValidItem = false;
        $('#Telefono').siblings('span.error').css('visibility', 'visible');
        $('#Telefono').siblings('span.error').css('color', 'red');
    }
    else {
        $('#Telefono').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Tipo').val().trim() == '') {
        isValidItem = false;
        $('#Tipo').siblings('span.error').css('visibility', 'visible');
        $('#Tipo').siblings('span.error').css('color', 'red');
    }
    else {
        $('#Tipo').siblings('span.error').css('visibility', 'hidden');
    }
    if (isValidItem) {  
        if ($('#TelPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else 
            vPrincipal = false;
        telItems.Agregar({
         TelefonoID:0,
     NumeroTelefono: $('#Telefono').val().trim(),
     Tipo:$('#Tipo').val().trim(),
    Principal: vPrincipal,
        });
        $('#Telefono').val('').focus();
        $('#Tipo').val('');
        $('#TelPrincipal').attr('checked', false);
    }
    MostrarTelefono(true);
}

function MostrarTelefono(editar) {
    $('#telItems').html('');
    if (telItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped table-responsive"/>');
        if (editar){
            $table.append('<thead><tr><th>Telefono</th><th>Tipo</th><th>Opcion</th></tr></thead>')
        }
        else {
           
            $table.append('<thead><tr><th>Telefono</th><th>Tipo</th></tr></thead>')
        }
        var $tbody = $('<tbody/>');
        for (var i = 0; i < telItems.Total() ; i++) {
           
            var $row = $('<tr/>');
            $row.append($('<td/>').html(telItems.Item(i).NumeroTelefono));
            $row.append($('<td/>').html(telItems.Item(i).Tipo));
            $row.append($('<td/>').html(telItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarTel(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#telItems').html($table);
    }
}

function EliminarTel(indice) {
    telItems.Eliminar(indice);
    MostrarTelefono(true);
    return false;

}

function addDir_Click() {
    var isValidItem = true;
    if ($('#Calle').val().trim() == '') {
        isValidItem = false;
        $('#Calle').siblings('span.error').css('visibility', 'visible');
        $('#Calle').siblings('span.error').css('color', 'red');
    }
    else {
        $('#Calle').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#NumExterior').val().trim() == '') {
       
        isValidItem = false;
        $('#NumExterior').siblings('span.error').css('visibility', 'visible');
        $('#NumExterior').siblings('span.error').css('color', 'red');
    }
    else {
        $('#NumExterior').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Municipio').val().trim() == '') {
        
        isValidItem = false;
        $('#Municipio').siblings('span.error').css('visibility', 'visible');
        $('#Municipio').siblings('span.error').css('color', 'red');
    }
    else {
        $('#Municipio').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Estado').val().trim() == '') {
               isValidItem = false;
        $('#Estado').siblings('span.error').css('visibility', 'visible');
        $('#Estado').siblings('span.error').css('color', 'red');
    }
    else {
        $('#Estado').siblings('span.error').css('visibility', 'hidden');
    }
    if (isValidItem) {
        if ($('#DirPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else
             vPrincipal = false;
             direccionesItem.Agregar({
             DireccionID:0,
             calle: $('#Calle').val().trim(),
             NumExterior: $('#NumExterior').val().trim(),
             NumInterior: $('#NumInterior').val().trim(),
             Colonia: $('#Colonia').val().trim(),
             Minucipio: $('#Municipio').val().trim(),
             Estado: $('#Estado').val().trim(),
             Principal: $('#DirPrincipal').val().trim(),
             });
            
        $('#Calle').val('').focus();
        $('#NumExterior').val('');
        $('#NumInterior').val('');
        $('#Colonia').val('');
        $('#Municipio').val('');
        $('#Estado').val('');
        $('#DirPrincipal').attr('checked', false);
    }
   
    MostrarDirecciones(true);
}

function MostrarDirecciones(editar) {
    $('#direccionesItems').html('');
    if (direccionesItem.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped table-responsive"/>');
        if (editar) {
            $table.append('<thead><tr><th>Calle</th><th>Numero Exterior</th><th>Numero Interior</th><th>Colonia</th><th>Municipio</th><th>Estado</th><th>Principal</th></tr></thead>')
        }
        else {
            $table.append('<thead><tr><th>Calle</th><th>Numero Exterior</th><th>Numero Interior</th><th>Colonia</th><th>Municipio</th><th>Estado</th></tr></thead>')
        }
        var $tbody = $('<tbody/>');
       
            for (var i = 0; i < direccionesItem.Total() ; i++) {
               
                var $row = $('<tr/>');
                $row.append($('<td/>').html(direccionesItem.Item(i).calle));
                $row.append($('<td/>').html(direccionesItem.Item(i).NumExterior));
                $row.append($('<td/>').html(direccionesItem.Item(i).NumInterior));
                $row.append($('<td/>').html(direccionesItem.Item(i).Colonia));
                $row.append($('<td/>').html(direccionesItem.Item(i).Minucipio));
                $row.append($('<td/>').html(direccionesItem.Item(i).Estado));
                $row.append($('<td/>').html(direccionesItem.Item(i).Principal));
                if (editar) {
                    $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarDir(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
                }
                $tbody.append($row);
            }
      
            $table.append($tbody);
            $('#direccionesItems').html($table);
       
       
    }
}

function EliminarDir(indice) {
    direccionesItem.Eliminar(indice);
    MostrarDirecciones(true);
    return false;

}

function addMail_Click() {
    var isValidItem = true;
    if ($('#Mail').val().trim() == '') {
        isValidItem = false;
        $('#Mail').siblings('span.error').css('visibility', 'visible');
        $('#Mail').siblings('span.error').css('color', 'red');
    }
    else {
        $('#Mail').siblings('span.error').css('visibility', 'hidden');
    }
   
    if (isValidItem) {
        if ($('#EmailPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else
            vPrincipal = false;
        emailItems.Agregar({
        EmailID : 0,
        Direccion: $('#Mail').val().trim(),
        Principal: vPrincipal,
        });
        $('#Mail').val('').focus();
        $('#EmailPrincipal').attr('checked', false);
    }
    MostrarEmail(true);
}

function MostrarEmail(editar) {
    $('#emailItems').html('');
    if (emailItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped table-responsive"/>');
        if (editar) {
            $table.append('<thead><tr><th>Direccion de Correo</th><th>Principal</th></tr></thead>')
        }
        else {
            $table.append('<thead><tr><th>Direccion de Correo</th></tr></thead>')
        }
        var $tbody = $('<tbody/>');
        for (var i = 0; i < emailItems.Total() ; i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(emailItems.Item(i).Direccion));
            $row.append($('<td/>').html(emailItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarEmail(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#emailItems').html($table);
    }
}

function EliminarEmail(indice) {
    emailItems.Eliminar(indice);
    MostrarEmail(true);
    return false;

}

function crear_Click() {
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

       $.ajax({
           url: '/Clientes/Create',
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