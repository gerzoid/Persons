export class Table {
    update({tableId, name, database, shema, tableName, description, countRecords, createdAt, updatedAt, expiredAt, settings}) {
        this.tableId = tableId;
        this.name = name;
        this.database = database;
        this.shema = shema;
        this.tableName = tableName;
        this.description = description;
        this.countRecords = countRecords;
        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
        this.expiredAt = expiredAt;
        this.settings = settings;
    }
    constructor() {
        this.tableId = 0;
        this.name = null;
        this.database =  null;
        this.shema =  null;
        this.tableName =  null;
        this.description =  null;
        this.countRecords = 0
        this.createdAt =  null;
        this.updatedAt =  null;
        this.expiredAt =  null;
        this.settings =  null;
    }

}