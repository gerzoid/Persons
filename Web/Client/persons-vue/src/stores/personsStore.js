import { defineStore } from 'pinia'
import Api from '../utils/api';

export const usePersonsStore = defineStore('personsStore', {
    state: () => ({
        loading: false,
        table:[],
        tableData:[],
        columns:[],
    }),
    getters: {
    },
    actions: {
      async openTable(tableId) {
        try {
            const result = await Api.OpenTable(tableId);
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