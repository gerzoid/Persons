import { defineStore } from 'pinia'
import Api from '../utils/api';

export const useTablesStore = defineStore('tablesStore', {
    state: () => ({
        loading: false,
        tables:[],  //Список таблиц
        table:{
            name: null,
            database: null,
            shema: null,
            tableName: null,
            description: null,
            countRecords:0,
            notFoundTable: false,
            }
    }),
    getters: {
    },
    actions: {
        async loadTable(tableId) {
            this.loading = true;
            try {
                const result = await Api.GetTable(tableId);
              this.tables = result.data;
              return this.tables;
            } catch (error) {
              console.error(error);
              throw error;
            } finally {
              this.loading = false;
            }
          },
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
              try {
                    const result  = await Api.CheckExistTable(database, shema, tableName);
                    this.table.countRecords = result.data;
                    return this.table.countRecords;
               } catch  (error)  {
                   console.error(error);
                throw error;
               } finally  {
                 this.loading  = false;
               }
            },
          },
    });