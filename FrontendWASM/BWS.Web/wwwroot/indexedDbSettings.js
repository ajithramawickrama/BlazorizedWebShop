export async function synchronizeFileWithIndexedDb(filename, dbName) {

    await createProductStore(filename, dbName);
   
    function createProductStore(filename,dbName) {
        return new Promise((res, rej) => {
            const db = window.indexedDB.open(dbName);

            db.onupgradeneeded = () => {
                db.result.createObjectStore('Products', { keypath: 'Id' });
            };

            db.onsuccess = () => {
                const reqProduct = db.result.transaction('Products', 'readonly').objectStore('Products').get('products');
                reqProduct.onsuccess = () => {
                    Module.FS_createDataFile('/', filename, reqProduct.result, true, true, true);
                    res();
                };
            };

            let lastModifiedTime = new Date();
            setInterval(() => {
                const path = `/${filename}`;
                if (FS.analyzePath(path).exists) {
                    const mtime = FS.stat(path).mtime;
                    if (mtime.valueOf() !== lastModifiedTime.valueOf()) {
                        lastModifiedTime = mtime;
                        const data = FS.readFile(path);
                        db.result.transaction('Products', 'readwrite').objectStore('Products').put(data, 'products');
                    }
                }
            }, 1000);
        });


    }
   
    
    
}
