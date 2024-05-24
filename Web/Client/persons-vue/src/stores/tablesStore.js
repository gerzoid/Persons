import { defineStore } from 'pinia'
import Api from '../utils/api';

export const useTablesStore = defineStore('tablesStore', {
    state: () => ({
        loading: false,
        tables:[],
        tableData:[],
        columns:[],
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
    },
  })