$(document).ready(function () {
    
    //call for the final add registration
    $('#myform').on('submit', function (e) {
        e.preventDefault();
        var isvalid = true;
        //name
            if ($('#txtname').val() == '') {
                isvalid = false;
                $('#lblname').text('Enter the name');
            } else {
                $('#lblname').text('');
            }
        //email
            if ($('#txtemail').val() == '') {
                isvalid = false;
                $('#lblemail').text('Enter the email');
            } else {
                var formate = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
                if (formate.test($('#txtemail').val())) {
                    $('#lblemail').text('');
                } else {
                    $('#lblemail').text('Please enter the right formate');
                }
            }
        //phone
            if ($('#txtphone').val() == '') {
                isvalid = false;
                $('#lblphone').text('Enter the phone no');
            } else {
                var formate = /^\d{10}$/
                if (formate.test($('#txtphone').val())) {
                    $('#lblphone').text('');
                } else {
                    $('#lblphone').text('Please enter the 10 number');
                }
            }
        //state
            if ($('#selectState').val() == 0) {
                isvalid = false;
                $('#lblstate').text('Please select the state');
            } else {
                $('#lblstate').text('');
            }
        //city
            if ($('#cityDropdown').val() == 0) {
                isvalid = false;
                $('#lblcity').text('Please select the state');
            } else {
                $('#lblcity').text('');
            }
        //checkbox
        if (!$('#chkbox').is(':checked')) {
            isvalid = false;
            $('#lblagree').text('Please Agrre before submit')
        } else {
            $('#lblagree').text('');
        }
        var id = $('#txtid').val()
        if (!id || id === '0') {
            id = 0;
        }
        if (isvalid) {
            $.ajax({
                type: "POST",
                url: "https://localhost:44397/Registration/AddRegistration",
                datType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    Id: id,
                    Name: $('#txtname').val(),
                    Email: $('#txtemail').val(),
                    Phone: $('#txtphone').val(),
                    Address: $('#txtaddress').val(),
                    SateId: $('#selectState').val(),
                    CityId: $('#cityDropdown').val()
                }),
                success: function (response) {
                    alert('Registration Added Or Updated successfully!')
                    $('#mainmodal').modal('hide');
                    location.reload();
                }
            })
        }
    })

    //update userRegistration

    $('#btnclose').on('click', function () {
        e.preventDefault();
        $('#mainmodal').modal('hide');
    })
    $('#btnopenModel').on('click', function () {
        $('#mainmodal').modal('show');
        $('#btnupdate001').hide();
        $('#btnadd').show();
    })
    $('#selectState').on('change', function () {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44397/Registration/GetCityByStatus/' + $(this).val(),
            datatype: 'text',
            success: function (mess) {
                var dropdown = $('#cityDropdown')
                dropdown.empty();
                dropdown.append('<option value="0">Select city</option>')
                $.each(mess, function (index, city) {
                    dropdown.append('<option value="' + city.id + '">' + city.cityName + '</option>');
                })
            }
        })
    })

})