$(document).ready(function () {
    $('#table_reader').DataTable({
        "responsive": {
            "breakpoints": [
                { "name": 'bigdesktop', width: Infinity },
                { "name": 'meddesktop', width: 1480 },
                { "name": 'smalldesktop', width: 1280 },
                { "name": 'medium', width: 1188 },
                { "name": 'tabletl', width: 1024 },
                { "name": 'btwtabllandp', width: 848 },
                { "name": 'tabletp', width: 768 },
                { "name": 'mobilel', width: 480 },
                { "name": 'mobilep', width: 320 }
            ]
        },
        "columnDefs": [{
            "targets": 'no-sort',
            "orderable": false,
        }],
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "zeroRecords": "No se encontraron registros",
            "info": "Mostrando del _START_ al _END_ de _MAX_ registros",
            "infoEmpty": "No se encontraron registros",
            "infoFiltered": "(filtrado de _MAX_ registros totales)",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "search": "Buscar:"
        }
    });
});