import { defineStore } from 'pinia'
import Api from '../utils/api';
import { readonly } from 'vue';

export const usePersonsStore = defineStore('personsStore', {
    state: () => ({
        tableId: null,
        loading: false,
        tableData:[], //Сами данные таблицы
        columns:[],   //Список колонок получаемый с сервера, необходим для инициализации handsonontable
    }),
    getters: {
    },
    actions: {
      setTableId(id){
        this.tableId = id;
      },
        async openTable() {
        this.loading = true;
        try {
            const result = await Api.OpenTable(this.tableId);
            this.columns = result.data.columns;
            this.formattingColumns();
            return this.tables;
        } catch (error) {
            console.error(error);
            throw error;
        } finally {
            this.loading = false;
        }
      },
      //Форматирование колонок Даты - mm.yy.dddd
      async getDataFromPersons() {
        this.loading = true;
        try {
            const result = await Api.GetDataFromPersons(this.tableId);
            this.tableData = result.data;
            return this.tables;
        } catch (error) {
            console.error(error);
            throw error;
        } finally {
            this.loading = false;
        }
      },
      formattingColumns(){
        var columns = this.columns.map(element => {
          if (element.type === "date") {
            element.dateFormat='DD.MM.YYYY';
          }
          return element;
        });
      }
    },
  })