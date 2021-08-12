$(function () {
    var l = abp.localization.getResource('BookStore');       /*获取一个函数，与客户端共享本地化值*/
    var createModal = new abp.ModalManager(abp.appPath + 'Books/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Books/EditModal');
    var dataTable = $('#BooksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(lhr.bookStore.books.book.getList),        /*帮助abp的动态js api代理跟Datatable的格式相适应的辅助方法*/
            columnDefs: [
               
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Type'),
                    data: "type",
                    render: function (data) {
                        return l('Enum:BookType:' + data);
                    }
                },
                {
                    title: l('PublishDate'),
                    data: "publishDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('操作'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                 
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                

                            ]
                    }
                },
                {
                    title: l('操作'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            '您确定要删除这条记录吗?',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.bookStore.books.book
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('删除成功')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }


                            ]
                    }
                }
               
            ]
        })
    );
   

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewBookButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
