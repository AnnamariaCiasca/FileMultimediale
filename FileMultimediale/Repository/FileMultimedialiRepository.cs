using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediale
{
    class FileMultimedialiRepository : IRepository<FileMultimediale>
    {
        CanzoniRepository canzoniRepository = new CanzoniRepository();
        PodcastRepository podcastRepository = new PodcastRepository();


        public List<FileMultimediale> Fetch()
        {
            List<FileMultimediale> files = new List<FileMultimediale>();

            files.AddRange(canzoniRepository.Fetch());
            files.AddRange(podcastRepository.Fetch());


            return files;
        }
    }
}
