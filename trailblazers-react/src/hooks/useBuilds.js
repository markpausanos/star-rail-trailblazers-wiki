import { useState, useEffect } from "react";

import * as Services from "../services";

const useBuilds = () => {
  const [builds, setBuilds] = useState(null);

  useEffect(() => {
    const getBuilds = async () => {
      try {
        const { data: getBuildResponse } = await Services.BuildsService.list();
        setBuilds(getBuildResponse);
      } catch (error) {
        console.error("Error fetching build", error);
      }
    };

    getBuilds();
  }, []);

  return { builds };
};

export default useBuilds;
