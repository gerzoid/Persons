import { defineStore } from 'pinia'
import Api from '../utils/api';

export const useTablesStore = defineStore('tablesStore', {
    state: () => ({
        loading: false,
        tables:[],  //Список таблиц
        table:{
          tableId:null,
          name: null,
          database: null,
          shema: null,
          tableName: null,
          description: null,
          countRecords:0,
          notFoundTable: false,
          createdAt: null,
          updatedAt: null,
          expiredAt: null,
          }
    }),
    getters: {
    },
    actions: {
          setNotFoundTable(finded) {
            this.table.notFoundTable = finded;
          },
          async loadTable(tableId) {
            this.loading = true;
            try {
                const result = await Api.GetTable(tableId);
                this.table = result.data;
              return this.table;
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
                    return this.table.countRecords
                }).catch((error) => {
                  if (error.response.status === 404) {
                      this.table.countRecords = 0;
                      //this.table.notFoundTable = true;
                      throw error;
                  }
                }).finally(() => this.loading  = false );
          },
    }
})