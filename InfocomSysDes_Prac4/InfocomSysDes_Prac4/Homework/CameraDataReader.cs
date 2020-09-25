using System;
using System.Collections.Generic;

namespace Homework {
    public class Camera {
        Random random;

        public Camera() {
            random = new Random();
        }

        public double getUnstructuredData() {
            return random.Next(10);
        }
    }

    public class CameraDataReader : ICameraReader {
        Camera camera;

        public CameraDataReader(Camera cam) {
            camera = cam;
        }

        public int getStructuredData() {
            return (int) camera.getUnstructuredData();
        }
    }

    public class DataReaderCollection {
        List<ICameraReader> readers;

        public DataReaderCollection(int count) {
            readers = new List<ICameraReader>();
            for (int i = 0; i < count; i++) {
                readers.Add(new CameraDataReader(new Camera()));
            }
        }

        public List<int> getActualData() {
            List<int> actualData = new List<int>();
            foreach (ICameraReader reader in readers) {
                actualData.Add(reader.getStructuredData());
            }
            return actualData;
        }
    }
}
