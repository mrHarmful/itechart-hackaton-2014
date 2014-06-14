using System;
using System.Collections;
using System.IO;
using log4net.ObjectRenderer;

namespace Seed.Logging.ObjectRenders
{
    internal class ExceptionRender : IObjectRenderer
    {
        public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            var exception = obj as Exception;

            while (exception != null)
            {
                WriteException(exception, writer);
                exception = exception.InnerException;
            }
        }

        private void WriteException(Exception ex, TextWriter writer)
        {
            writer.WriteLine("Type: {0}", ex.GetType().FullName);
            writer.WriteLine("Message: {0}", ex.Message);
            writer.WriteLine("Source: {0}", ex.Source);
            writer.WriteLine("TargetSite: {0}", ex.TargetSite);
            WriteExceptionData(ex, writer);
            writer.WriteLine("StackTrace: {0}", ex.StackTrace);
        }

        private void WriteExceptionData(Exception ex, TextWriter writer)
        {
            foreach (DictionaryEntry entry in ex.Data)
            {
                writer.WriteLine("{0}: {1}", entry.Key, entry.Value);
            }
        }
    }
}