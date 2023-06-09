using BelajarASPCore.Models;

namespace BelajarASPCore.DAL {
    public interface IMahasiswa {

        //membuat methode getAll
        public IEnumerable<Mahasiswa> getAll();
        public IEnumerable<Mahasiswa> getByNim(string nim);

    }
}