module Example.Datasource {

    let ds = new kendo.data.DataSource();
    $(() => {

        $('#grid').kendoGrid();

        $('#btnFillValues').bind('click', fillValues);
        $('#btnViewData').bind('click', showData);
        $('#btnAddTupple').bind('click', addTupple);
        $('#btnRemoveByIndex').bind('click', removeByIndex);
        $('#txtFileterText').bind('keyup', search);
        $('#btnViewFirstIndex').bind('click', getItemByIndex);
        $('#btnInsert').bind('click', insert);
        $('#btnAddToGrid').bind('click', addToGrid);
        $('#btnDeleteFilterdRows').bind('click', searchAndRemove);
        $('#btnSearchAndUpdate').bind('click', searchAndUpdate);
    });

    function fillValues() {

        var data = [
            { name: "Jane Doe", age: 30 },
            { name: "Chamith Saranga", age: 33 }
        ];
        ds.data(data);
    }

    function showData() {
        var view = ds.view();
        $.each(view, (i, d) => {
            console.log(d.name);
        });
        $('#grid').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: view }));
    }
    function addTupple() {
        ds.add({ name: 'sajeeka', age: 20 });
    }

    function removeByIndex() {
        ds.remove(ds.at(0));
    }

    function getItemByIndex() {
        var dataItem: any = ds.at(0);
        alert(dataItem.name);
    }
    function removeMultiple() {
        var val = $('#txtFileterText').val();
        //ds.remove(ds.filter({ field: "name", operator: "startswith", value: val }));
    }

    //Inserts a data item in the data source at the specified index.
    function insert() {
        ds.insert(1, { name: "Kasun Chathuranga", age: 20 });
        showData();
    }

    function search() {
        var val = $('#txtFileterText').val();
        console.log(val);
        ds.filter({ field: "name", operator: "startswith", value: val });
        showData();
    }

    function addToGrid() {

        ds.insert(0, { name: $('#txtName').val(), age: Number($('#txtAge').val()) });
        showData();
    }

    function searchAndRemove() {
 
        $.each(ds.data(), (i, d) => {
            if (d.name === $('#txtFileterText').val()){
                ds.remove(ds.at(i));
            }
        });
        showData();
    }

    function searchAndUpdate() {
        $.each(ds.data(), (i, d) => {
            if (d.name === $('#txtFileterText').val()) {
                d.age = 55;
            }
        });
        showData();
    }
}