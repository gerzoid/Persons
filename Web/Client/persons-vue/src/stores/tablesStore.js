import { defineStore } from 'pinia'
import Api from '../utils/api';

export const useTablesStore = defineStore('tablesStore', {
    state: () => ({
        loading: false,
        tables:[],
        tableData:[],
    }),
    getters: {
    },
    actions: {
        getTable(tableId){
            self=this;
            this.loading=true;
            return new Promise(function(resolve, reject){
                Api.GetTable(tableId)
                .then((result) => {
                    self.tables = result.data;
                    self.loading=false;
                    resolve(self.tables);
                })
                .catch((e) => {
                    console.log(e);
                    self.loading=false;
                    reject(e);
                })
            })
        },
        getTables(){
            self=this;
            this.loading=true;
            return new Promise(function(resolve, reject){
                Api.GetTables()
                .then((result) => {
                    self.tables = result.data;
                    self.loading=false;
                    resolve(self.tables);
                })
                .catch((e) => {
                    console.log(e);
                    self.loading=false;
                    reject(e);
                })
            })
        },
    },
  })