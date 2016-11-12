var app = {
    init() {
        this.currencySymbol = $('#currencyFormatter').val();
        $('#dateOfBirth').datepicker({ format: "dd/mm/yyyy" });
        $('#dateOfJoin').datepicker({ format: "dd/mm/yyyy" });
        $('#salary').autoNumeric('init', { aSign: this.currencySymbol });
        $('form').validate();
    }
}

$(() => {
    app.init();
})