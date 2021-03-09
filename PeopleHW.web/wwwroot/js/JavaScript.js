$(() => {
    let counter = 1;
    $("#add-button").on('click', function () {
        $("#span").append(`<div class='row col-md-12 '> 
                            <input type = 'text' name = 'people[${counter}].FirstName' placeholder = 'FirstName' class= 'form-control col-md-3' /> 
                            <input type='text' name='people[${counter}].LastName' placeholder='LastName' class='form-control col-md-3' /> 
                            <input type='text' name='people[${counter}].Age' placeholder='Age' class='form-control col-md-3' /> </div >`);
        counter++;
    });
});
