﻿/*global angular*/
(function () {
    angular
        .module('simplAdmin.inventory')
        .controller('WarehouseListCtrl', WarehouseListCtrl);

    /* @ngInject */
    function WarehouseListCtrl(warehouseService, translateService, $state) {
        var vm = this,
            tableStateRef;
        vm.warehouses = [];
        vm.translate = translateService;

        vm.getWarehouses = function (tableState) {
            tableStateRef = tableState;
            vm.isLoading = true;
            warehouseService.getWarehouses(tableState).then(function (result) {
                vm.warehouses = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                vm.isLoading = false;
            });
        };

        vm.deleteWarehouse = function (warehouse) {
            bootbox.confirm('Are you sure you want to delete this warehouse: ' + warehouse.name, function (result) {
                if (result) {
                    warehouseService.deleteWarehouse(warehouse)
                        .then(function (result) {
                            vm.getWarehouses(tableStateRef);
                            toastr.success(warehouse.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };
    }
})();