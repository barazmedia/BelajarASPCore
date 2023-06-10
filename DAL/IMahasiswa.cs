using BelajarASPCore.Models;

namespace BelajarASPCore.DAL {
    public interface IMahasiswa {

        //membuat methode getAll
        public IEnumerable<Mahasiswa> getAll();
        public IEnumerable<Mahasiswa> getByNim(string nim);
        public void Insert(Mahasiswa mhs);
        public Mahasiswa getById(string nim);
        public void Update(Mahasiswa mhs);

    }
}