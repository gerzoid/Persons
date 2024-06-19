import { defineStore } from 'pinia'
import { Table } from '../models/table';
import Api from '../utils/api';

export const useTablesStore = defineStore('tablesStore', {
    state: () => ({
        loading: false,
        tables:[],  //Список таблиц
        addingNewTable: false,  //Добавление или редактирование таблицы
        validation:{
          notFoundTable: false, //Признак наличия таблицы на сервере
          checked: false, //Признак проверки наличия таблицы на сервере, влияет на кнопку Сохранить
        },
        table:new Table(),
    }),
    getters: {
    },
    actions: {
          setNotFoundTable(finded) {
            this.validation.notFoundTable = finded;
          },
          async loadTable(tableId) {
            this.loading = true;
            try {
                const result = await Api.GetTable(tableId);
                this.table = result.data;
              //return this.table;
            } catch (error) {
              console.error(error);
              throw error;
            } finally {
              this.loading = false;
            }
          },
          //Список всех таблиц
          async loadTables() {
            this.loading = true;
            try {
                const result = await Api.GetTables();
              this.tables = result.data;
              return this.tables;
            } catch (error) {
              console.error(error);
              throw error;
            } finally {
              this.loading = false;
            }
          },
          async CheckExistTable(database, shema, tableName) {
              this.loading  = true;
                const resp  =  await Api.CheckExistTable(database, shema, tableName).then((response) => {
                    this.table.countRecords = response.data;
                    this.validation.checked  =  true;
                    return this.table.countRecords
                }).catch((error) => {
                  if (error.response.status === 404) {
                      this.table.countRecords = 0;
                      this.validation.checked  =  false;
                      tablesStore.validation.notFoundTable  =  true;
                      throw error;
                  }
                }).finally(() => this.loading  = false );
          },
          async SaveTable() {
            if (this.addingNewTable) {
                const result = await Api.CreateTable(this.table);
            }
            if (!this.addingNewTable) {const result  = await Api.SaveTable(this.table);
               this.table  =  result.data;
               this.addingNewTable  =  false;
           }
            const result = await Api.SaveTable(this.table, this.addingNewTable);
          }
    }
})